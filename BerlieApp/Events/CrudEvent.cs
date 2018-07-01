using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.Events
{
    class CrudEvent<T>
    {
        public enum CrudEventType
        {
            Create, Modify, Delete
        }

        public CrudEvent(T entity, CrudEventType crudEventType)
        {
            Entity = entity;
            Event = crudEventType;
        }

        public CrudEventType Event { get; }
        public T Entity { get; }
        
    }
}
