using BenchmarkDotNet.Running;

namespace hw11
{
    public static class Program
    {
        public static void Main() => BenchmarkRunner.Run<BenchmarkTests>();
    }
}
