using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly HashSet<Shirt> hashShirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.           
        }


        public SearchResults Search(SearchOptions options)
        {
            var shirts = _shirts.SearchShirtColorsAndSizes(options.Colors, options.Sizes).ToList();

            return new SearchResults
            {
                ColorCounts = shirts.ShirtColorCounts(options.Colors).ToList(),
                Shirts = shirts,
                SizeCounts = shirts.ShirtSizeCounts(options.Sizes).ToList()
            };
        }
    }
}