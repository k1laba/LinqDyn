using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDyn.Tests
{
    public class ProductFilter
    {
        [FilterInfo(FilterOperator.None)]
        public int Id { get; set; }
        [FilterInfo(FilterOperator.GreaterOrEqual, "Id")]
        public int FromId { get; set; }
        [FilterInfo(FilterOperator.LessOrEqual, "Id")]
        public int ToId { get; set; }
        [FilterInfo(FilterOperator.Contains)]
        public string Name { get; set; }
        [FilterInfo(FilterOperator.GreaterOrEqual)]
        public int SortOrder { get; set; }
    }
}
