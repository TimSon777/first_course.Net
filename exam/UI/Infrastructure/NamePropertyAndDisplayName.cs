using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace UI.Infrastructure
{
    public class NamePropertyAndDisplayName
    {
        private Dictionary<string, string> _propertyNameAndDisplayName = new();

        public string FindDisplayName(string propertyName)
        {
            _propertyNameAndDisplayName.TryGetValue(propertyName, out var result);
            return result;
        }
        
        public void Fill(Type type) 
            => _propertyNameAndDisplayName = type
                .GetProperties()
                .AsParallel()
                .Where(a => a.GetCustomAttribute<DisplayNameAttribute>() is not null)
                .Select(a => (a.Name, a.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName))
                .ToDictionary(a => a.Name, a => a.DisplayName);
    }
}