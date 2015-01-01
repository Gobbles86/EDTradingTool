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
            return CreateProfitList(BuildLookupHash(localStation), BuildLookupHash(remoteStation));
        }

        public static List<ProfitEntry> CreateProfitList(
            Dictionary<Entity.CommodityType, Entity.MarketEntry> localLookupHash,
            Dictionary<Entity.CommodityType, Entity.MarketEntry> remoteLookupHash
            )
        {
            // Retrieve only those commodity types for which both stations have an entry defined.
            var allCommodityTypes = localLookupHash.Keys.Intersect(remoteLookupHash.Keys);

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

        public static ProfitEntry CreateProfitEntry(Entity.CommodityType commodityType, Entity.MarketEntry localMarketEntry, Entity.MarketEntry remoteMarketEntry)
        {
            var profitEntry = new ProfitEntry()
            {
                GroupName = commodityType.CommodityGroup.Name,
                TypeName = commodityType.Name,
                BuyFromMarketPrice = localMarketEntry.BuyFromStationPrice,
                SellToMarketPrice = remoteMarketEntry.SellToStationPrice,
                LastBuyPriceUpdate = localMarketEntry.LastUpdate,
                LastSellPriceUpdate = remoteMarketEntry.LastUpdate
            };

            if (profitEntry.BuyFromMarketPrice.HasValue && profitEntry.SellToMarketPrice.HasValue)
            {
                profitEntry.Profit = profitEntry.SellToMarketPrice - profitEntry.BuyFromMarketPrice;
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
