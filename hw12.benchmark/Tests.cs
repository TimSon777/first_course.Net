using System.ComponentModel;
using BenchmarkDotNet.Attributes;

namespace hw12.benchmark
{
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    [MemoryDiagnoser]
    public class Tests
    {
        const string String = "Строка";

        private DifferentMethods Instance { get; set; }
        
        [GlobalSetup]
        public void Setup()
        {
            Instance = new DifferentMethods();
        }
        
        [Benchmark(Description = "Обычный метод")]
        public void SimpleMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                Instance.Simple(String);
            }
        }
        
        [Benchmark(Description = "Виртуальный метод")]
        public void VirtualMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                Instance.Virtual(String);
            }
        }
        
        [Benchmark(Description = "Дженерик метод")]
        public void GenericMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                Instance.Generic(String);
            }
        }
        
        [Benchmark(Description = "Статический метод")]
        public void StaticMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                DifferentMethods.Static(String);
            }
        }
        
        [Benchmark(Description = "Метод с дайнамиком")]
        public void DynamicMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                Instance.Dynamic(String);
            }
        }
        
        [Benchmark(Description = "Метод с рефлексией")]
        public void ReflectionMethod()
        {
            for (var i = 0; i < 1; i++)
            {
                var method = Instance.GetType().GetMethod("Reflection");
                method?.Invoke(Instance, new object?[] { String });
            } 
        }
    }
}