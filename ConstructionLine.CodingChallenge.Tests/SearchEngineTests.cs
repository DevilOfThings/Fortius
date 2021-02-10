using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{

    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        [TestCase(new object[] { "Red" }, new object[] { "Small" }, new object[] { "Red;Small","Black;Medium", "Blue;Large" })]
        [TestCase(new object[] { "Red", "Black" }, new object[] { "Small" }, new object[] { "Red;Small", "Black;Medium", "Blue;Large" })]
        [TestCase(new object[] { "Red" }, new object[] { "Small", "Medium" }, new object[] { "Red;Small", "Black;Medium", "Blue;Large" })]
        [TestCase(new object[] { "Red", "Black" }, new object[] { "Small", "Medium" }, new object[] { "Red;Small", "Black;Medium", "Blue;Large" })]
        [TestCase(new object[] { "Red", "Black" }, new object[] { "Small", "Medium" }, new object[] { "Red;Small", "Black;Medium", "Blue;Large", "Red;Small", "Black;Medium", "Blue;Large" })]
        [TestCase(new object[] { "Red", "Black", "Blue" }, new object[] { "Small", "Medium" }, new object[] { "Red;Small", "Black;Medium", "Blue;Large", "Red;Small", "Black;Medium", "Blue;Large" })]
        public void Test(object[] colors, object[] sizes, object[] o_shirts)
        {
            var shirts = new List<Shirt>();
            foreach (string shirt in o_shirts)
            {
                shirts.Add(new Shirt(Guid.NewGuid(), $"{shirt.ShirtName()}", shirt.ShirtSize(), shirt.ShirtColor()));
            }
            
            var searchEngine = new SearchEngine(shirts);
            
            var searchOptions = new SearchOptions
            {
                Colors = colors.Cast<string>().ShirtColors().ToList(),
                Sizes = sizes.Cast<string>().ShirtSizes().ToList()
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }
    }
}
