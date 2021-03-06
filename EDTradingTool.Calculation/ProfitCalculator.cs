﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Calculation
{
    /// <summary>
    /// This class is used for calculating profit which can be made on trades.
    /// </summary>
    public class ProfitCalculator
    {
        public static List<ProfitEntry> CreateProfitList(Entity.SpaceStation localStation, Entity.SpaceStation remoteStation)
        {
            if (remoteStation == null)
            {
                return CreateProfitListForTradesFromStation(localStation);
            }
            if (localStation == null)
            {
                return CreateProfitListForTradesToStation(remoteStation);
            }
            else
            {
                return CreateProfitList(BuildLookupHash(localStation), BuildLookupHash(remoteStation));
            }
        }

        public static List<ProfitEntry> CreateProfitList(
            Dictionary<Entity.CommodityType, Entity.MarketEntry> localLookupHash,
            Dictionary<Entity.CommodityType, Entity.MarketEntry> remoteLookupHash
            )
        {
            // Retrieve only those commodity types for which the first station sells and the second station buys
            var localCommoditiesForSale =
                localLookupHash.Where(keyValuePair => keyValuePair.Value.BuyFromStationPrice.HasValue && keyValuePair.Value.BuyFromStationPrice > 0)
                .Select(keyValuePair => keyValuePair.Key);

            var remotelyBoughtCommodities = 
                remoteLookupHash.Where(keyValuePair => keyValuePair.Value.SellToStationPrice.HasValue && keyValuePair.Value.SellToStationPrice > 0)
                .Select(keyValuePair => keyValuePair.Key);

            var allCommodityTypes = localCommoditiesForSale.Intersect(remotelyBoughtCommodities);

            var orderedCommodityGroups = allCommodityTypes.Select(x => x.CommodityGroup)
                                                          .Distinct()
                                                          .OrderBy(y => y.Name);

            var profitList = new List<ProfitEntry>();

            foreach (var commodityGroup in orderedCommodityGroups)
            {
                var orderedCommodityTypes = commodityGroup.CommodityTypes.Intersect(allCommodityTypes)
                                                                         .OrderBy(x => x.Name);

                foreach (var commodityType in orderedCommodityTypes)
                {
                    profitList.Add(CreateProfitEntry(commodityType, localLookupHash[commodityType], remoteLookupHash[commodityType]));
                }
            }

            return profitList;
        }

        public static List<ProfitEntry> CreateGlobalProfitList(IEnumerable<Entity.CommodityGroup> commodityGroups)
        {
            var profitList = new List<ProfitEntry>();

            // Retrieve all commodity groups 
            var orderedGroups = commodityGroups.OrderBy(group => group.Name);

            foreach (var currentGroup in orderedGroups)
            {
                var typesForCurrentGroup = currentGroup.CommodityTypes.OrderBy(type => type.Name);

                foreach (var currentType in typesForCurrentGroup)
                {
                    // Find the stations with the least sell price and the highest buy price
                    var bestSellPriceEntry = FindBestMarketEntry(currentType, findSeller: true);
                    if (bestSellPriceEntry == null) continue;
                    var bestBuyPriceEntry = FindBestMarketEntry(currentType, findSeller: false);
                    if (bestBuyPriceEntry == null) continue;

                    profitList.Add(CreateProfitEntry(currentType, bestSellPriceEntry, bestBuyPriceEntry));
                }
            }

            return profitList;
        }
        
        public static List<ProfitEntry> CreateProfitListForTradesFromStation(Entity.SpaceStation localStation)
        {
            var profitList = new List<ProfitEntry>();

            // Retrieve all Commodity Types which are sold at the curren station
            // Sort them first by Commodity Group, then by Commodity Type
            var marketEntriesForSale = localStation.MarketEntries.Where(entry => entry.BuyFromStationPrice.HasValue && entry.BuyFromStationPrice != 0)
                                                                 .OrderBy(entry => entry.CommodityType.CommodityGroup.Name)
                                                                 .ThenBy(entry => entry.CommodityType.Name);

            foreach (var marketEntry in marketEntriesForSale)
            {
                var bestBuyPriceEntry = FindBestMarketEntry(marketEntry.CommodityType, findSeller: false);

                // Skip if no best buyer could be retrieved or if the retrieved price was invalid or lower than the local station's sell price
                if (bestBuyPriceEntry == null) continue;
                if (!bestBuyPriceEntry.SellToStationPrice.HasValue || bestBuyPriceEntry.SellToStationPrice.Value == 0) continue;
                if (bestBuyPriceEntry.SellToStationPrice.Value <= marketEntry.BuyFromStationPrice) continue;

                profitList.Add(CreateProfitEntry(marketEntry.CommodityType, marketEntry, bestBuyPriceEntry));
            }
            return profitList;
        }

        public static List<ProfitEntry> CreateProfitListForTradesToStation(Entity.SpaceStation localStation)
        {
            var profitList = new List<ProfitEntry>();

            // Retrieve all Commodity Types which are bought at the curren station
            // Sort them first by Commodity Group, then by Commodity Type
            var marketBuyEntries = localStation.MarketEntries.Where(entry => entry.SellToStationPrice.HasValue && entry.SellToStationPrice != 0)
                                                             .OrderBy(entry => entry.CommodityType.CommodityGroup.Name)
                                                             .ThenBy(entry => entry.CommodityType.Name);

            foreach (var marketEntry in marketBuyEntries)
            {
                var bestSellPriceEntry = FindBestMarketEntry(marketEntry.CommodityType, findSeller: true);

                // Skip if no best buyer could be retrieved or if the retrieved price was invalid or lower than the local station's sell price
                if (bestSellPriceEntry == null) continue;
                if (!bestSellPriceEntry.BuyFromStationPrice.HasValue || bestSellPriceEntry.BuyFromStationPrice.Value == 0) continue;
                if (bestSellPriceEntry.BuyFromStationPrice.Value >= marketEntry.SellToStationPrice) continue;

                profitList.Add(CreateProfitEntry(marketEntry.CommodityType, bestSellPriceEntry, marketEntry));
            }
            return profitList;
        }

        /// <summary>
        /// Runs over the list of market entries for the given commodity type and returns the entry with the highest buy price or the lowest 
        /// sell price.
        /// </summary>
        /// <param name="commodityType">The commodity type to handle.</param>
        /// <param name="findSeller">True if the best seller shall be found, false if the best buyer shall be found.</param>
        /// <returns>The space station with the best price.</returns>
        public static Entity.MarketEntry FindBestMarketEntry(Entity.CommodityType commodityType, bool findSeller)
        {
            Func<Entity.MarketEntry, int?> sortFunction = entry => findSeller ? entry.BuyFromStationPrice : entry.SellToStationPrice;
            Func<Entity.MarketEntry, bool> hasValueFunction = entry => findSeller ? entry.BuyFromStationPrice.HasValue : entry.SellToStationPrice.HasValue;

            var results = commodityType.MarketEntries.Where(hasValueFunction).OrderBy(sortFunction);

            if (results.Count() == 0) return null;

            return findSeller ? results.First() : results.Last();
        }

        /// <summary>
        /// Retrieves the best profit which can be made when buying at supplierStation and selling at demanderStation, respecting a maximumCostPerUnit.
        /// </summary>
        /// <param name="supplierStation">The name of the station which sells stuff.</param>
        /// <param name="demanderStation">The name of the station which buys stuff.</param>
        /// <param name="maximumCostPerUnit">The maximum cost per unit.</param>
        /// <returns>The best profit entry, or null if no such entry exists.</returns>
        public static ProfitEntry FindBestProfitEntry(Entity.SpaceStation supplierStation, Entity.SpaceStation demanderStation, int maximumCostPerUnit)
        {
            var profits = CreateProfitList(supplierStation, demanderStation)
                          .Where(entry => entry.BuyFromMarketPrice.Value <= maximumCostPerUnit && entry.Profit.Value > 0)
                          .OrderByDescending(entry => entry.Profit)
                          .ThenByDescending(entry => entry.ProfitPerInvestment);

            if (profits.Count() == 0) return null;

            return profits.First();
        }

        /// <summary>
        /// Retrieves the best profits for a round trip between two stations.
        /// </summary>
        /// <param name="allStations">The list of all space stations.</param>
        /// <param name="maximumCostPerUnit">The maximum cost per unit.</param>
        /// <returns>A list with two profit entries (one for each direction).</returns>
        public static List<ProfitEntry> FindBestRoundTrip(List<Entity.SpaceStation> allStations, int maximumCostPerUnit)
        {
            int highestProfit = 0;
            ProfitEntry profitEntry1 = null;
            ProfitEntry profitEntry2 = null;

            foreach (var spaceStation1 in allStations)
            {
                foreach (var spaceStation2 in allStations)
                {
                    var bestProfitEntry1 = Calculation.ProfitCalculator.FindBestProfitEntry(spaceStation1, spaceStation2, maximumCostPerUnit);
                    var bestProfitEntry2 = Calculation.ProfitCalculator.FindBestProfitEntry(spaceStation2, spaceStation1, maximumCostPerUnit);

                    if (bestProfitEntry1 == null || bestProfitEntry2 == null) continue;

                    var totalProfit = (bestProfitEntry1.Profit.Value + bestProfitEntry2.Profit.Value);

                    if (totalProfit > highestProfit)
                    {
                        highestProfit = totalProfit;
                        profitEntry1 = bestProfitEntry1;
                        profitEntry2 = bestProfitEntry2;
                    }
                }
            }

            if (profitEntry1 == null || profitEntry2 == null) return null;

            return new List<ProfitEntry>() { profitEntry1, profitEntry2 };
        }

        /// <summary>
        /// Retrieves the best profits for a round trip between two stations.
        /// </summary>
        /// <param name="allStations">The list of all space stations.</param>
        /// <param name="maximumCostPerUnit">The maximum cost per unit.</param>
        /// <returns>A list with two profit entries (one for each direction).</returns>
        public static List<ProfitEntry> FindBestRoundTripForThreeStations(List<Entity.SpaceStation> allStations, int maximumCostPerUnit)
        {
            int highestProfit = 0;
            ProfitEntry profitEntry1 = null;
            ProfitEntry profitEntry2 = null;
            ProfitEntry profitEntry3 = null;

            foreach (var spaceStation1 in allStations)
            {
                foreach (var spaceStation2 in allStations)
                {
                    foreach (var spaceStation3 in allStations)
                    {
                        var bestProfitEntry1 = Calculation.ProfitCalculator.FindBestProfitEntry(spaceStation1, spaceStation2, maximumCostPerUnit);
                        var bestProfitEntry2 = Calculation.ProfitCalculator.FindBestProfitEntry(spaceStation2, spaceStation3, maximumCostPerUnit);
                        var bestProfitEntry3 = Calculation.ProfitCalculator.FindBestProfitEntry(spaceStation3, spaceStation1, maximumCostPerUnit);

                        if (bestProfitEntry1 == null || bestProfitEntry2 == null || bestProfitEntry3 == null) continue;

                        var totalProfit = (bestProfitEntry1.Profit.Value + bestProfitEntry2.Profit.Value + bestProfitEntry3.Profit.Value);

                        if (totalProfit > highestProfit)
                        {
                            highestProfit = totalProfit;
                            profitEntry1 = bestProfitEntry1;
                            profitEntry2 = bestProfitEntry2;
                            profitEntry3 = bestProfitEntry3;
                        }
                    }
                }
            }

            if (profitEntry1 == null || profitEntry2 == null || profitEntry3 == null) return null;

            return new List<ProfitEntry>() { profitEntry1, profitEntry2, profitEntry3 };
        }


        public static ProfitEntry CreateProfitEntry(
            Entity.CommodityType commodityType, Entity.MarketEntry localMarketEntry, Entity.MarketEntry remoteMarketEntry
            )
        {
            var profitEntry = new ProfitEntry()
            {
                CommodityGroup = commodityType.CommodityGroup,
                CommodityType = commodityType,
                LocalStation = localMarketEntry.SpaceStation,
                RemoteStation = remoteMarketEntry.SpaceStation,
                LocalSystem = localMarketEntry.SpaceStation.SolarSystem,
                RemoteSystem = remoteMarketEntry.SpaceStation.SolarSystem,
                BuyFromMarketPrice = localMarketEntry.BuyFromStationPrice,
                SellToMarketPrice = remoteMarketEntry.SellToStationPrice,                
                Supply = localMarketEntry.Supply,
                Demand = remoteMarketEntry.Demand,
                LastBuyPriceUpdate = localMarketEntry.LastUpdate,
                LastSellPriceUpdate = remoteMarketEntry.LastUpdate
            };

            if (profitEntry.BuyFromMarketPrice.HasValue && profitEntry.SellToMarketPrice.HasValue)
            {
                profitEntry.Profit = profitEntry.SellToMarketPrice - profitEntry.BuyFromMarketPrice;
                profitEntry.ProfitPerInvestment = (int)((double)profitEntry.Profit / (double)profitEntry.BuyFromMarketPrice * 100.0);
            }

            return profitEntry;
        }

        private static Dictionary<Entity.CommodityType, Entity.MarketEntry> BuildLookupHash(Entity.SpaceStation spaceStation)
        {
            var lookupHash = new Dictionary<Entity.CommodityType, Entity.MarketEntry>();

            if (spaceStation != null)
            {
                foreach (var marketEntry in spaceStation.MarketEntries)
                {
                    lookupHash.Add(marketEntry.CommodityType, marketEntry);
                }
            }

            return lookupHash;
        }
    }
}
