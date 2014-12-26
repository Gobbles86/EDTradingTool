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

            // Create a controller
            var controller = new Controller(entityManagerFactory);
            
            // Create a GUI
            var mainForm = new GUI.MainForm();
            mainForm.Initialize(controller);
                        
            controller.Initialize(entityAccess);

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
                Demand = null
            };

            controller.AddObject(solarSystem);
            controller.AddObject(federation);
            controller.AddObject(spaceStation, federation, solarSystem);

            controller.AddObject(commodityGroup);
            controller.AddObject(commodityType, commodityGroup);

            controller.AddObject(marketEntry, commodityType, spaceStation);


            // Example: Print all output from market entry only

            Console.WriteLine(
                "Solar System \"" + marketEntry.SpaceStation.SolarSystem.Name + "\" has a station \"" + marketEntry.SpaceStation.Name + "\" owned by federation \"" +
                marketEntry.SpaceStation.Federation.Name + "\" and has the following market entry:\n" +
                "BuyFromStation Price = " + marketEntry.BuyFromStationPrice.ToString() + "\n" +
                "Supply = " + marketEntry.Supply.ToString() + "\n" +
                "Commodity Type = \"" + marketEntry.CommodityType.Name + "\"\n" +
                "Commodity Group = \"" + marketEntry.CommodityType.CommodityGroup.Name + "\""
                );

            Application.Run(mainForm);
        }
    }
}
