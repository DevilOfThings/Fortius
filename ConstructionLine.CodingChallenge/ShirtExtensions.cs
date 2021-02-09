using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public static class ShirtExtensions
    {        
        public static IReadOnlyCollection<SizeCount> ShirtSizeCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Size> sizes)
        {
            var query =
                    from sz in Size.All
                    join s in (from s2 in shirts
                               where sizes.Contains(s2.Size)
                               select s2)
                            on sz.Id equals s.Size.Id
                            into grp
                    select new SizeCount() { Size = sz, Count = grp.Count() };

            return query.ToList();           
        }

        public static IReadOnlyCollection<ColorCount> ShirtColorCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Color> colors)
        {
            var query =
                    from c in Color.All
                    join s in (from s2 in shirts
                               where colors.Contains(s2.Color)
                               select s2)
                            on c.Id equals s.Color.Id
                            into grp
                    select new ColorCount { Color = c, Count = grp.Count() };

            return query.ToList();            
        }

        public static IReadOnlyCollection<Shirt> SearchShirtColorsAndSizes(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Color> colors, IReadOnlyCollection<Size> sizes)
        {                        
            var query = from s in shirts
                   from c in colors
                   from z in sizes
                   where s.Color.Id == c.Id
                   where s.Size.Id == z.Id
                   select s;

            return query.ToList();
        }
    }
}