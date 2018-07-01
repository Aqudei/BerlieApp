using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.Model
{
    abstract class EntityBase : IEquatable<EntityBase>
    {
        public int Id { get; set; }
        public abstract string EntityCode { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase);
        }

        public bool Equals(EntityBase other)
        {
            return other != null &&
                   Id == other.Id &&
                   EntityCode == other.EntityCode;
        }

        public override int GetHashCode()
        {
            var hashCode = -1290401001;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EntityCode);
            return hashCode;
        }

        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            return EqualityComparer<EntityBase>.Default.Equals(base1, base2);
        }

        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return !(base1 == base2);
        }
    }
}
