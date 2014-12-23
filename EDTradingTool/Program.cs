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

            var dbFactory = new OrmLiteConnectionFactory(
                "./db.sqlite", SqliteDialect.Provider, false
                );

            Core.IEntityAccess entityAccess = new Data.EntityAccess(dbFactory);
            Core.AbstractEntityManager<Entity.SpaceStation> spaceStationManager = new Data.SpaceStationManager(entityAccess);
            Core.AbstractEntityManager<Entity.Federation> federationManager = new Data.FederationManager(entityAccess);
            Core.AbstractEntityManager<Entity.SolarSystem> solarSystemManager = new Data.SolarSystemManager(entityAccess, spaceStationManager);
            
            entityAccess.DeleteAll();
            entityAccess.LoadAll();

            var solarSystem = new Entity.SolarSystem() { Name = "Test System" };
            var federation = new Entity.Federation() { Name = "Test Federation" };
            var spaceStation = new Entity.SpaceStation() { Name = "Test Station" };

            solarSystemManager.AddObject(solarSystem);
            federationManager.AddObject(federation);
            spaceStationManager.AddObject(spaceStation, solarSystem, federation);

            Console.WriteLine(spaceStation.Name + " / " + spaceStation.Federation.Name + " / " + spaceStation.SolarSystem.Name);
        }
    }
}
