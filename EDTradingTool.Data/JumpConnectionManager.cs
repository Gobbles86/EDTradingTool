using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Data
{
    /// <summary>
    /// This class is responsible for keeping data integrity clean when accessing the JumpConnection table.
    /// </summary>
    public class JumpConnectionManager : Core.AbstractEntityManager<Entity.JumpConnection>
    {
        /// <summary>
        /// Defines the types of related objects which are required for adding a jump connection.
        /// </summary>
        private static readonly Type[] RelatedTypes = new Type[]
        {
            typeof(Entity.SpaceStation),
            typeof(Entity.SpaceStation)
        };

        public JumpConnectionManager(Core.IEntityAccess entityAccess)
            : base(entityAccess)
        {
        }

        /// <summary>
        /// Adds the jump connection and links it to the given Space Stations
        /// </summary>
        /// <param name="jumpConnection">The jump connection entry to add.</param>
        /// <param name="parentObjects">The Space Stations to link to.</param>
        public override void AddObject(Entity.JumpConnection jumpConnection, params Core.IEntity[] parentObjects)
        {
            ValidateParentObjects(parentObjects, RelatedTypes);

            var spaceStation1 = (Entity.SpaceStation)parentObjects[0];
            var spaceStation2 = (Entity.SpaceStation)parentObjects[1];

            jumpConnection.SpaceStation1Id = spaceStation1.Id;
            jumpConnection.SpaceStation2Id = spaceStation2.Id;

            try
            {
                base.AddObject(jumpConnection, null);
            }
            catch
            {
                jumpConnection.SpaceStation1Id = null;
                jumpConnection.SpaceStation2Id = null;
                throw;
            }

            // In case of success, link the Jump Connection with the Space Stations.
            jumpConnection.SpaceStation1 = spaceStation1;
            jumpConnection.SpaceStation2 = spaceStation2;
            spaceStation1.JumpConnections.Add(jumpConnection);
            spaceStation2.JumpConnections.Add(jumpConnection);
        }

        /// <summary>
        /// Removes the Jump Connection and additionally unlinks it from its parent Space Stations.
        /// </summary>
        /// <param name="jumpConnection">The jump connection to remove.</param>
        public override void RemoveObject(Entity.JumpConnection jumpConnection)
        {
            // Unlink the class from its parent entities.
            if (jumpConnection.SpaceStation1 != null)
            {
                jumpConnection.SpaceStation1.JumpConnections.Remove(jumpConnection);
                jumpConnection.SpaceStation1 = null;
                jumpConnection.SpaceStation1Id = null;
            }
            if (jumpConnection.SpaceStation2 != null)
            {
                jumpConnection.SpaceStation2.JumpConnections.Remove(jumpConnection);
                jumpConnection.SpaceStation2 = null;
                jumpConnection.SpaceStation2Id = null;
            }
            base.RemoveObject(jumpConnection);
        }

    }
}
