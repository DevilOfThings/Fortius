using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge.Tests
{
    public static class TestExtensions
    {
        public static IEnumerable<Color> ShirtColors(this IEnumerable<string> colors) =>
        
            from s in colors
            from color in Color.All
            where color.Name == s
            select color;

        
        
        public static IEnumerable<Size> ShirtSizes(this IEnumerable<string> sizes) =>
        
            from s in sizes
            from size in Size.All
            where size.Name == s
            select size;


        public static string ShirtName(this string description) =>  $"{description.Split(';')[0]} - {description.Split(';')[1]}";
        
        public static Color ShirtColor(this string description) =>        
            (from c in Color.All
             where c.Name == description.Split(';')[0]
             select c).Single();

        public static Size ShirtSize(this string description) =>
            (from s in Size.All
             where s.Name == description.Split(';')[1]
            select s).Single();
    }
}
