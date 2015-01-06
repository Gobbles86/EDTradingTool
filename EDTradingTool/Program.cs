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
            var splashScreen = new SplashScreen();
            splashScreen.Show();

            OrmLiteConfig.DialectProvider = SqliteDialect.Provider;
            OrmLiteConfig.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();

            // Create a factory for database connections
            var dbFactory = new OrmLiteConnectionFactory(
                Environment.GetEnvironmentVariable("APPDATA") + @"\EDTradingTool\EDTradingToolDB.sqlite", SqliteDialect.Provider, false
                );

            // Create the class which is used for accessing entities
            Core.IEntityAccess entityAccess = new Data.EntityAccess(dbFactory);

            // Create a factory for entity managers which help keeping data integrity clean
            var entityManagerFactory = new Data.EntityManagerFactory(entityAccess);

            // Create a controller
            var controller = new Controller(entityManagerFactory, new EntityLinker(entityAccess), entityAccess.HandledTypes);
            
            // Create a GUI
            var mainForm = new GUI.MainForm(
                new GUI.Reports.CommodityTypeStatsHandler(), 
                new GUI.Reports.SpaceStationStatsHandler(controller),
                new GUI.Reports.CommodityGroupStatsHandler(controller)
                );
            mainForm.Initialize(controller);
            controller.Initialize(entityAccess);

            Test(controller);

            splashScreen.Hide();
            Application.Run(mainForm);
        }

        private static void Test(Controller controller)
        {
            var balance = 386429;
            var rebuyCost = 65923;
            var cargoSpace = 60;

            var availableAmount = balance - rebuyCost;
            var maxPrice = availableAmount / cargoSpace;

            var allStations = controller.GetEntityManager<Entity.SpaceStation>().GetAll();
            var profitEntries = Calculation.ProfitCalculator.FindBestRoundTrip(allStations, maxPrice);
            //var profitEntriesForThree = Calculation.ProfitCalculator.FindBestRoundTripForThreeStations(allStations, maxPrice);

            if (profitEntries == null) return;

            var profitEntry1 = profitEntries[0];
            var profitEntry2 = profitEntries[1];

            Console.WriteLine(String.Format(
                "The highest average profit between two stations with {9} cash flow can be made like this: \n" +
                "{0} / {1}: {2} (Profit: {3})\n" +
                "{4} / {5}: {6} (Profit: {7})\n" +
                "({8} Profit per unit on average).",
                profitEntry1.LocalSystem, profitEntry1.LocalStation, profitEntry1.CommodityType, profitEntry1.Profit,
                profitEntry2.LocalSystem, profitEntry2.LocalStation, profitEntry2.CommodityType, profitEntry2.Profit,
                (profitEntry1.Profit + profitEntry2.Profit) / 2.0, availableAmount
                ));

            if (profitEntriesForThree == null) return;

            //profitEntry1 = profitEntriesForThree[0];
            //profitEntry2 = profitEntriesForThree[1];
            //var profitEntry3 = profitEntriesForThree[2];

            //Console.WriteLine(String.Format(
            //    "The highest average profit between three stations with {13} cash flow can be made like this: \n" +
            //    "{0} / {1}: {2} (Profit: {3})\n" +
            //    "{4} / {5}: {6} (Profit: {7})\n" +
            //    "{8} / {9}: {10} (Profit: {11})\n" +
            //    "({12} Profit per unit on average).",
            //    profitEntry1.LocalSystem, profitEntry1.LocalStation, profitEntry1.CommodityType, profitEntry1.Profit,
            //    profitEntry2.LocalSystem, profitEntry2.LocalStation, profitEntry2.CommodityType, profitEntry2.Profit,
            //    profitEntry3.LocalSystem, profitEntry3.LocalStation, profitEntry3.CommodityType, profitEntry3.Profit,
            //    (profitEntry1.Profit + profitEntry2.Profit + profitEntry3.Profit) / 3.0, availableAmount
            //    ));
        }
    }
}
