using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LinqByObjectFilter;

namespace LinqByObjectFilter.Tests
{
    public class ExtensionsTests
    {
        List<Product> _list = new List<Product>();
        public ExtensionsTests()
        {
            _list.Add(new Product() { Id = 3, SortOrder = 3, Name = "123" });
            _list.Add(new Product() { Id = 1, SortOrder = 1, Name = "abc" });
            _list.Add(new Product() { Id = 8, SortOrder = 8, Name = "987" });
            _list.Add(new Product() { Id = 4, SortOrder = 4, Name = "beqakilaba" });
            _list.Add(new Product() { Id = 2, SortOrder = 20, Name = "456" });
            _list.Add(new Product() { Id = 6, SortOrder = 6, Name = "test" });
            _list.Add(new Product() { Id = 5, SortOrder = 5, Name = "kilaba" });
            _list.Add(new Product() { Id = 10, SortOrder = 10, Name = "bek" });
            _list.Add(new Product() { Id = 7, SortOrder = 7, Name = "beq" });
            _list.Add(new Product() { Id = 9, SortOrder = 9, Name = "beqa" });
        }
        [Fact]
        public void OrderBy_WhenCalls_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _list.OrderBy(i => i.SortOrder).ToList();
            //act
            var sorted = _list.AsQueryable().OrderBy("SortOrder").ToList();
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void OrderByDescending_WhenCalls_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _list.OrderByDescending(i => i.SortOrder).ToList();
            //act
            var sorted = _list.AsQueryable().OrderByDescending("SortOrder").ToList();
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void FilterBy_WhenCalls_ShouldOrderCorrectly()
        {
            //arrange
            var filter = new ProductFilter() { Id = 1, SortOrder = 5, Name = "beq", FromId = 4, ToId = 9 };
            var expected = _list.Where(i => i.Id >= filter.FromId && i.Id <= filter.ToId)
                                .Where(i => i.Name.Contains(filter.Name))
                                .Where(i => i.SortOrder >= filter.SortOrder).ToList();
            //act
            var actual = _list.AsQueryable().FilterBy(filter).ToList();
            //assert
            Assert.True(expected.SequenceEqual(actual));
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
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
