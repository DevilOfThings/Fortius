using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public static class ShirtExtensions
    {        
        public static IEnumerable<SizeCount> ShirtSizeCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Size> sizes)
        {
            var query =
                    from all in Size.All                    
                    join z in sizes on all.Id equals z.Id into grp
                    join s in shirts on all.Id equals s.Size.Id into available                                                         
                    select new SizeCount() { Size = all, Count = available.Count() };
            
            return query;          
        }

        public static IEnumerable<ColorCount> ShirtColorCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Color> colors)
        {
            var query =
                    from all in Color.All
                    join z in colors on all.Id equals z.Id into grp
                    join s in shirts on all.Id equals s.Color.Id into available
                    select new ColorCount() { Color = all, Count = available.Count() };

            return query;           
        }

        public static IEnumerable<Shirt> SearchShirtColorsAndSizes(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Color> colors, IReadOnlyCollection<Size> sizes)
        {                        
            var query = from s in shirts
                   from c in colors
                   from z in sizes
                   where s.Color.Id == c.Id
                   where s.Size.Id == z.Id
                   select s;

            return query;
        }
    }
}