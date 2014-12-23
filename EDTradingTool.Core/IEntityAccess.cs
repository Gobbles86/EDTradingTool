using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDTradingTool.Core
{
    /// <summary>
    /// This interface must be implemented by classes which access database entities directly.
    /// </summary>
    public interface IEntityAccess
    {
        long AddObject<T>(T obj) where T : class, Core.IHasId;
        void UpdateObject<T>(T obj) where T : class, Core.IHasId;
        void RemoveObject<T>(T obj) where T : class, Core.IHasId;
        T GetObject<T>(long primaryKey) where T : class, Core.IHasId;
        T GetObject<T>(String name) where T : class, Core.IHasName;
        bool HasObject<T>(long primaryKey) where T : class, Core.IHasId;
        bool HasObject<T>(String name) where T : class, Core.IHasName;
        void LoadAll();
        void DeleteAll();
    }
}
