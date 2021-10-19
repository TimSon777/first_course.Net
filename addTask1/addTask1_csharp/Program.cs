using System;
using Microsoft.FSharp.Core;

namespace addTask1_csharp
{
    public static class Program
    {
        public static int Main()
        {
            var a = FSharpOption<int>.Some(1);
            var b = FSharpOption<int>.Some(3);
            var result = MaybeBuilder.Bind(a, new ResultBind(b));
            Console.WriteLine(result == null ? "None" : result.Value);
            return 0;
        }
    }
}