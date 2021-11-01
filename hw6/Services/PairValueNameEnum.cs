using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace hw6.Services
{
    public record PairValueNameEnum(int Value, string Name)
    {
        public static IEnumerable<PairValueNameEnum> GetEnum(PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType;
            
            var names = type
                .GetEnumNames();
            
            var values = type
                .GetEnumValues()
                .Cast<int>()
                .ToArray();
            
            return values.Select((v, i) => new PairValueNameEnum(v, names[i]));
        }
    }
}