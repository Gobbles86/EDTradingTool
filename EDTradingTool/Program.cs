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
                new GUI.Reports.CommodityTypeStatsHandler(), new GUI.Reports.SpaceStationStatsHandler(controller)
                );
            mainForm.Initialize(controller);
            controller.Initialize(entityAccess);

            // Create a couple of dummy entries

            // Example: Print all output from market entry only
            Application.Run(mainForm);
        }
    }
}
