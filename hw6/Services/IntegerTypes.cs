using System;
using System.Linq;

namespace hw6.Services
{
    public class IntegerTypes
    {
        public readonly Type[] Nullables;
        public readonly Type[] Normals;

        public IntegerTypes(Type[] nullables, Type[] normals)
        {
            if (nullables.Length != normals.Length) throw new ArgumentException();
            
            Nullables = nullables;
            Normals = normals;
        }

        public bool IsContains(Type type)
        {
            return Normals.Contains(type) || Nullables.Contains(type);
        }
        
        public static readonly IntegerTypes WholeTypes = new(
            new[]
            {
                typeof(int?),
                typeof(double?)
            }, 
            new[]
            {
                typeof(int),
                typeof(double)
            });
    }
}