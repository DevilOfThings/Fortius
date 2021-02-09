using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public static class ShirtExtensions
    {        
        public static IReadOnlyCollection<SizeCount> ShirtSizeCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Size> sizes)
        {            
            var query = from s in shirts
                        from z in sizes
                        where s.Size.Id == z.Id
                        group s by s.Size.Name into sizeGrps
                        from a in Size.All
                        select new { Size = a, Count = sizeGrps.Count(x=>x.Size.Name == a.Name) } into shirtSizes
                        select new SizeCount { Size = shirtSizes.Size, Count = shirtSizes.Count };

            return query.ToList();
        }

        public static IReadOnlyCollection<ColorCount> ShirtColorCounts(this IReadOnlyCollection<Shirt> shirts, IReadOnlyCollection<Color> colors)
        {
            var query = from s in shirts
                        from c in colors
                        where s.Color.Id == c.Id
                        group s by c.Name into colorGrps
                        from a in Color.All
                        select new { Color = a, Count = colorGrps.Count(x=>x.Color.Name == a.Name) } into shirtColors
                        select new ColorCount { Color = shirtColors.Color, Count = shirtColors.Count };

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