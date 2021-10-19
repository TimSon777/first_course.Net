using Microsoft.FSharp.Core;

namespace addTask1_csharp
{
    public static class MaybeBuilder
    {
        public static FSharpOption<TZero> Zero<TZero>() => null;

        public static FSharpOption<TFunc> Bind<TElement, TFunc>(FSharpOption<TElement> x,
            FSharpFunc<TElement, FSharpOption<TFunc>> f) => x == null ? null : f.Invoke(x.Value);
        
        public static FSharpOption<TReturn> Return<TReturn>(TReturn x) => FSharpOption<TReturn>.Some(x);
    }
}