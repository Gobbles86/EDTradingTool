using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.GUI.Reports
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
                return CreateProfitListForStation(localStation);
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
        
        public static List<ProfitEntry> CreateProfitListForStation(Entity.SpaceStation localStation)
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

        public static ProfitEntry CreateProfitEntry(
            Entity.CommodityType commodityType, Entity.MarketEntry localMarketEntry, Entity.MarketEntry remoteMarketEntry
            )
        {
            var profitEntry = new ProfitEntry()
            {
                GroupName = commodityType.CommodityGroup.Name,
                TypeName = commodityType.Name,
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
