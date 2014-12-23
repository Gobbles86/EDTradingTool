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
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // TEMP TEST
            OrmLiteConfig.DialectProvider = SqliteDialect.Provider;
            OrmLiteConfig.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();

            var dbFactory = new OrmLiteConnectionFactory(
                "./db.sqlite", SqliteDialect.Provider, false
                );

            var entityAccess = new Data.EntityAccess(dbFactory);
            var spaceStationManager = new Data.SpaceStationManager(entityAccess);
            var federationManager = new Data.FederationManager(entityAccess);
            var solarSystemManager = new Data.SolarSystemManager(entityAccess, spaceStationManager);
            
            entityAccess.DeleteAll();
            entityAccess.LoadAll();

            var solarSystem = new Entity.SolarSystem() { Name = "Test System" };
            var federation = new Entity.Federation() { Name = "Test Federation" };
            var spaceStation = new Entity.SpaceStation() { Name = "Test Station" };

            solarSystemManager.AddSolarSystem(solarSystem);
            federationManager.AddFederation(federation);
            spaceStationManager.AddSpaceStation(spaceStation, solarSystem, federation);

            Console.WriteLine(spaceStation.Name + " / " + spaceStation.Federation.Name + " / " + spaceStation.SolarSystem.Name);
        }
    }
}
