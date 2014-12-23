using ServiceStack.OrmLite;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace EDTradingTool
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                RunMain();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
#if DEBUG
                message += "\n\nStack Trace:\n" + ex.StackTrace;
#endif
                MessageBox.Show(
                    message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                    );
            }
        }

        private static void RunMain()
        {
            // TEMP TEST
            OrmLiteConfig.DialectProvider = SqliteDialect.Provider;
            OrmLiteConfig.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();

            // Create a factory for database connections
            var dbFactory = new OrmLiteConnectionFactory(
                "./db.sqlite", SqliteDialect.Provider, false
                );

            // Create the class which is used for accessing entities
            Core.IEntityAccess entityAccess = new Data.EntityAccess(dbFactory);

            // Create a factory for entity managers which help keeping data integrity clean
            var entityManagerFactory = new Data.EntityManagerFactory(entityAccess);

            // Retrieve the required entity managers
            var solarSystemManager = entityManagerFactory.GetManagerFor<Entity.SolarSystem>();
            var federationManager = entityManagerFactory.GetManagerFor<Entity.Federation>();
            var spaceStationManager = entityManagerFactory.GetManagerFor<Entity.SpaceStation>();
            var commodityGroupManager = entityManagerFactory.GetManagerFor<Entity.CommodityGroup>();
            var commodityTypeManager = entityManagerFactory.GetManagerFor<Entity.CommodityType>();
            var marketEntryManager = entityManagerFactory.GetManagerFor<Entity.MarketEntry>();

            // Reset database (will obviously be removed as soon as data can be entered by the user)
            // If this gets removed, existing links must be re-established as they are not stored in the database (apart from the foreign key)
            entityAccess.DeleteAll();
            entityAccess.LoadAll();


            
            // Create a couple of dummy entries
            var solarSystem = new Entity.SolarSystem() { Name = "Test System" };
            var federation = new Entity.Federation() { Name = "Test Federation" };
            var spaceStation = new Entity.SpaceStation() { Name = "Test Station" };
            var commodityGroup = new Entity.CommodityGroup() { Name = "Test Commodity Group" };
            var commodityType = new Entity.CommodityType() { Name = "Test Commodity Type" };
            var marketEntry = new Entity.MarketEntry()
            {
                BuyFromStationPrice = 1234,
                SellToStationPrice = null,
                Supply = 12345,
                Demand = null,
                LastUpdate = DateTime.Now
            };

            solarSystemManager.AddObject(solarSystem);
            federationManager.AddObject(federation);
            spaceStationManager.AddObject(spaceStation, federation, solarSystem);

            commodityGroupManager.AddObject(commodityGroup);
            commodityTypeManager.AddObject(commodityType, commodityGroup);

            marketEntryManager.AddObject(marketEntry, commodityType, spaceStation);


            // Example: Print all output from market entry only

            Console.WriteLine(
                "Solar System \"" + marketEntry.SpaceStation.SolarSystem.Name + "\" has a station \"" + marketEntry.SpaceStation.Name + "\" owned by federation \"" +
                marketEntry.SpaceStation.Federation.Name + "\" and has the following market entry:\n" +
                "BuyFromStation Price = " + marketEntry.BuyFromStationPrice.ToString() + "\n" +
                "Supply = " + marketEntry.Supply.ToString() + "\n" +
                "Commodity Type = \"" + marketEntry.CommodityType.Name + "\"\n" +
                "Commodity Group = \"" + marketEntry.CommodityType.CommodityGroup.Name + "\""
                );
        }
    }
}
