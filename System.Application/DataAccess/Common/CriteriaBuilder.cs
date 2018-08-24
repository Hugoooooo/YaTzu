using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Application.DataAccess.Common
{
    public class CriteriaBuilder
    {
        public static Criteria<T> From<T>()
        {
            return new Criteria<T>();
        }
    }
}
