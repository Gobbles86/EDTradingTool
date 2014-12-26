using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This class is a template base class for Entity Manager classes, i.e. classes which are responsible for keeping data integrity clean when accessing a specific entity table.
    /// This class also separates business logic from data access by using the IEntityAccess interface.
    /// </summary>
    public abstract class AbstractEntityManager<T> where T : IEntity
    {
        /// <summary>
        /// The data member which can be used for accessing entities.
        /// </summary>
        protected IEntityAccess EntityAccess { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="entityAccess">The object which can be used for accessing entities.</param>
        protected AbstractEntityManager(IEntityAccess entityAccess)
        {
            this.EntityAccess = entityAccess;
        }

        /// <summary>
        /// Stores the given object in the database and relates it to the given other classes.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        /// <param name="relatedObjects">The objects to the object to add is related to. By convention, the objects should be supplied in the alphabetical 
        /// order of their Entity Names.</param>
        public virtual void AddObject(T obj, params object[] relatedObjects)
        {
            EntityAccess.AddObject(obj);
        }

        /// <summary>
        /// Updates the given object in the database. Note that the ID may never be changed.
        /// </summary>
        /// <param name="obj">The object to update.</param>
        public virtual void UpdateObject(T obj)
        {
            EntityAccess.UpdateObject(obj);
        }

        /// <summary>
        /// Deletes the given object from the database.
        /// By convention, entity managers should always remove the object directly from its parent object and use entity managers of the child classes for removing the 
        /// child object from the object.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public virtual void RemoveObject(T obj)
        {
            EntityAccess.RemoveObject(obj);
        }

        /// <summary>
        /// Retrieves the object with the given primary key.
        /// </summary>
        /// <param name="primaryKey">The primary key of the object to retrieve.</param>
        /// <returns>The desired object.</returns>
        public virtual T GetObject(long primaryKey)
        {
            return EntityAccess.GetObject<T>(primaryKey);
        }

        /// <summary>
        /// Retrieves the object with the given name.
        /// </summary>
        /// <typeparam name="TEntityWithName">The type which implements IHasName. This is usually detected automatically.</typeparam>
        /// <param name="name">The name of the object to retrieve.</param>
        /// <returns>The desired object.</returns>
        public virtual T GetObject(String name)
        {
            return EntityAccess.GetObject<T>(name);
        }

        /// <summary>
        /// Checks if there is an object with the given primary key.
        /// </summary>
        /// <param name="primaryKey">The primary key of the object.</param>
        /// <returns>True if the object exists.</returns>
        public virtual bool HasObject(long primaryKey)
        {
            return EntityAccess.HasObject<T>(primaryKey);
        }

        /// <summary>
        /// Checks if ther eis an object with the given name.
        /// </summary>
        /// <typeparam name="TEntityWithName">The type which implements IHasName. This is usually detected automatically.</typeparam>
        /// <param name="name">The name of the object.</param>
        /// <returns>True if the object exists.</returns>
        public virtual bool HasObject<TEntityWithName>(String name) where TEntityWithName : IEntity
        {
            return EntityAccess.HasObject<TEntityWithName>(name);
        }

        /// <summary>
        /// Retrieves all entities of the handled type.
        /// </summary>
        /// <returns>All entities for the given type.</returns>
        public virtual List<T> GetAll()
        {
            return EntityAccess.GetAll<T>();
        }

        /// <summary>
        /// Makes sure the given list of related objects matches the list of expected types. This is intended for AddObject overrides.
        /// </summary>
        /// <param name="relatedObjects">The related objects which were supplied to the AddObject method.</param>
        /// <param name="expectedTypes">The types which are expected.</param>
        protected void ValidateRelatedObjects(object[] relatedObjects, Type[] expectedTypes)
        {
            if (relatedObjects == null && expectedTypes == null) return;

            if (expectedTypes == null || relatedObjects == null)
            {
                throw NewTypeMismatchException(relatedObjects, expectedTypes);
            }

            // At this point, neither relatedObjects nor expectedTypes is null.

            if( relatedObjects.Count() != expectedTypes.Count() )
            {
                throw NewTypeMismatchException(relatedObjects, expectedTypes);
            }

            // At this point, the lists have the same lengths, but the content could differ.

            for( int index = 0; index < relatedObjects.Count(); index++ )
            {
                if( relatedObjects[index].GetType() != expectedTypes[index])
                {
                    throw NewTypeMismatchException(relatedObjects, expectedTypes);
                }
            }

            // At this point, the types of the supplied related objects match the expected types.
        }

        /// <summary>
        /// Throws a mismatch exception which lists the expected object types and the types which were actually supplied.
        /// </summary>
        /// <param name="suppliedObjects">The objects which were supplied.</param>
        /// <param name="expectedTypes">The types which were expected.</param>
        /// <returns>A System.ArgumentException which can be thrown.</returns>
        protected Exception NewTypeMismatchException(object[] suppliedObjects, Type[] expectedTypes)
        {
            // Retreive the types of the supplied objects in a new array.
            Type[] suppliedObjectTypes = null;
            if (suppliedObjects != null)
            {
                suppliedObjectTypes = suppliedObjects.Select<object, Type>(x => x.GetType()).ToArray();
            }

            // Build readable lists of supplied and expected types
            var suppliedTypeString = GetDashedList(suppliedObjectTypes);
            var expectedTypeString = GetDashedList(expectedTypes);

            return new System.ArgumentException(
                String.Format(
                    "You tried adding a {0} entity and supplied the following related object types: {1}\n\nHowever, the following types were expected (in that order): {2}",
                    typeof(T).Name, suppliedTypeString, expectedTypeString
                    )
                );
        }

        /// <summary>
        /// Returns the given array of types as a single string which contains each entry in a new line with a dash each.
        /// </summary>
        /// <param name="types">The types to retriev the list for.</param>
        /// <returns>The list as single string.</returns>
        protected String GetDashedList(Type[] types)
        {
            if (types == null || types.Count() == 0)
            {
                return String.Empty;
            }

            const String newDashLine = "\n - ";

            var resultString = String.Empty;

            foreach(var type in types)
            {
                resultString += newDashLine + type.Name;
            }

            return resultString;
        }

    }
}
