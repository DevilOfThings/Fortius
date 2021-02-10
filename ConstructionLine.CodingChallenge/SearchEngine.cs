using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;        

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.           
        }


        public SearchResults Search(SearchOptions options)
        {
            var shirts = _shirts.SearchShirtColorsAndSizes(options.Colors, options.Sizes).ToList();

            var tasks = new List<Task>();
            var colors = Task.Run ( async () => await GetShirtColorCountsAsync(shirts, options));
            var sizes = Task.Run( async () => await GetShirtSizeCountsAsync(shirts, options) );
            Task.WhenAll(colors, sizes).ConfigureAwait(false).GetAwaiter();

            return new SearchResults
            {
                ColorCounts = colors.Result.ToList(),
                Shirts = shirts,
                SizeCounts = sizes.Result.ToList()
            };
        }

        private async Task<IEnumerable<ColorCount>> GetShirtColorCountsAsync(IReadOnlyCollection<Shirt> shirts, SearchOptions options)
        {
            return await Task.Run( () => shirts.ShirtColorCounts(options.Colors) );
        }

        private async Task<IEnumerable<SizeCount>> GetShirtSizeCountsAsync(IReadOnlyCollection<Shirt> shirts, SearchOptions options)
        {
            return await Task.Run( () => shirts.ShirtSizeCounts(options.Sizes) );
        }
    }
}