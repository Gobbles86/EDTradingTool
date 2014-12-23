using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for managing Entity.Federation objects.
    /// </summary>
    public class FederationManager
    {
        private EntityAccess _entityAccess;

        public FederationManager(EntityAccess entityAccess)
        {
            _entityAccess = entityAccess;
        }

        public void AddFederation(Entity.Federation federation)
        {
            _entityAccess.AddObject(federation);
        }

        public void RemoveFederation(Entity.Federation federation)
        {
            _entityAccess.RemoveObject(federation);
        }

        public void UpdateFederation(Entity.Federation federation)
        {
            _entityAccess.UpdateObject(federation);
        }

        public Entity.Federation GetFederation(long primaryKey)
        {
            return _entityAccess.GetObject<Entity.Federation>(primaryKey);
        }

        public Entity.Federation GetFederation(String name)
        {
            return _entityAccess.GetObject<Entity.Federation>(name);
        }
    }
}
