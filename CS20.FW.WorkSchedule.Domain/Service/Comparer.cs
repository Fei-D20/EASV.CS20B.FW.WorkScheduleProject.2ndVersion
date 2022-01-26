using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Domain.Service
{
    public class Comparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name && x.Password == y.Password && x.Role == y.Role;
        }

        public int GetHashCode(User obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.Password, (int)obj.Role);
        }
    }
}