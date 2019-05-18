using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NOC2
{
    public class Colors
    {
        private static readonly Dictionary<string, Color> dictionary =
            typeof(Color).GetProperties(BindingFlags.Public |
                                        BindingFlags.Static)
                         .Where(prop => prop.PropertyType == typeof(Color))
                         .ToDictionary(prop => prop.Name,
                                       prop => (Color)prop.GetValue(null, null));

        public Color FromName(string name)
        {
            return dictionary[name];
        }
    }
}
