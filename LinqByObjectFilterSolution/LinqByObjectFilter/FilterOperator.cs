using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqByObjectFilter
{
    public enum FilterOperator
    {
        None = 0,
        Equal = 1,
        GreaterOrEqual = 2,
        LessOrEqual = 3,
        Contains = 4,
    }
}
