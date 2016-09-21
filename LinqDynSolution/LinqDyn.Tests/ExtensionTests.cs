using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LinqDyn;
using LinqDyn.Tests.Repositories;

namespace LinqDyn.Tests
{
    public class ExtensionsTests
    {
        private ProductInMemoryRepository _repo;

        public ExtensionsTests()
        {
            _repo = new ProductInMemoryRepository();
        }
        [Fact]
        public void OrderBy_WhenCallsOnIQueryable_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _repo.LoadAll().OrderBy(i => i.SortOrder).ToList();
            //act
            var sorted = _repo.LoadAll().AsQueryable().OrderBy("SortOrder").ToList();
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void OrderByDescending_WhenCallsOnIQueryable_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _repo.LoadAll().OrderByDescending(i => i.SortOrder).ToList();
            //act
            var sorted = _repo.LoadAll().AsQueryable().OrderByDescending("SortOrder").ToList();
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void FilterBy_WhenCallsOnIQueryable_ShouldFilterCorrectly()
        {
            //arrange
            var filter = new ProductFilter() { Id = 1, SortOrder = 5, Name = "beq", FromId = 4, ToId = 9 };
            var obj = filter;
            var expected = _repo.LoadAll().Where(i => i.Id >= filter.FromId && i.Id <= filter.ToId)
                                          .Where(i => i.Name.Contains(filter.Name))
                                          .Where(i => i.SortOrder >= filter.SortOrder)
                                          .ToList();
            //act
            var actual = _repo.LoadAll().AsQueryable().FilterBy(obj).ToList();
            //assert
            Assert.True(expected.SequenceEqual(actual));
        }
        [Fact]
        public void OrderBy_WhenCallsOnIEnumerable_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _repo.LoadAll().OrderBy(i => i.SortOrder);
            //act
            var sorted = _repo.LoadAll().OrderBy("SortOrder");
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void OrderByDescending_WhenCallsOnIEnumerable_ShouldOrderCorrectly()
        {
            //arrange
            var expected = _repo.LoadAll().OrderByDescending(i => i.SortOrder).ToList();
            //act
            var sorted = _repo.LoadAll().OrderByDescending("SortOrder").ToList();
            //assert
            Assert.True(sorted.SequenceEqual(expected));
        }
        [Fact]
        public void FilterBy_WhenCallsOnIEnumerable_ShouldFilterCorrectly()
        {
            //arrange
            var filter = new ProductFilter() { Id = 1, SortOrder = 5, Name = "beq", FromId = 4, ToId = 9 };
            var obj = filter;
            var expected = _repo.LoadAll().Where(i => i.Id >= filter.FromId && i.Id <= filter.ToId)
                                          .Where(i => i.Name.Contains(filter.Name))
                                          .Where(i => i.SortOrder >= filter.SortOrder)
                                          .ToList();
            //act
            var actual = _repo.LoadAll().FilterBy(obj).ToList();
            //assert
            Assert.True(expected.SequenceEqual(actual));
        }
    }
}
