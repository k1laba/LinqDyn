using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDyn
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterInfoAttribute : Attribute
    {
        private FilterOperator _filterOperator = FilterOperator.Equal;
        private readonly string _targetPropertyName;

        public FilterInfoAttribute(FilterOperator filterOperator)
        {
            _filterOperator = filterOperator;
        }
        public FilterInfoAttribute(FilterOperator filterOperator, string TargetPropertyName) : this(filterOperator)
        {
            _targetPropertyName = TargetPropertyName;
        }
        public FilterOperator GetOperator()
        {
            return _filterOperator;
        }
        public string GetTargetPropertyName()
        {
            return _targetPropertyName;
        }
    }
}
