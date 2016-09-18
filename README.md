# LinqDyn
Added three extension methods for linq
<ul>
<li> OrderBy - Has property name as input parameter(like Linq.Dynamic) </li>
<li> OrderByDescending - Has property name as input parameter(like Linq.Dynamic) </li>
<li> FilterBy - Has strongly typed input parameter </li>
</ul>

#Code Example

```
  public class ProductFilter
  {
      [FilterInfo(FilterOperator.Contains)]
      public string Name { get; set; }
      [FilterInfo(FilterOperator.GreaterOrEqual)]
      public int SortOrder { get; set; }
  }
  ProductFilter filter = new ProductFilter() { Name = "test", SortOrder = 5 };
  var result1 = list.FilterBy(filter);
  var result2 = list.Where(i => i.SortOrder >= filter.SortOrder)
                    .Where(i => i.Name.Contains(filter.Name));
```
In the above example result1 and result2 has same results.
<br/>
<ul>
<li>
<code>list.OrderBy("SortOrder")</code> returns same result as <code>list.OrderBy(i => i.SortOrder)</code>
</li>
<li>
<code>list.OrderByDescending("SortOrder")</code> returns same result as <code>list.OrderByDescending(i => i.SortOrder)</code>
</li>
</ul>


