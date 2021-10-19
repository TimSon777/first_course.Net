using Microsoft.FSharp.Core;

namespace addTask1_csharp
{ 
    public class ResultReturn : FSharpFunc<int, FSharpOption<int>>
    {
        private readonly int _value;

        public ResultReturn(int value)
        {
            _value = value;
        }

        public override FSharpOption<int> Invoke(int arg) 
            => MaybeBuilder.Return(_value + arg);
    }

    public class ResultBind : FSharpFunc<int, FSharpOption<int>>
    {
        private readonly FSharpOption<int> _option;

        public ResultBind(FSharpOption<int> option)
        {
          _option = option;
        }

        public override FSharpOption<int> Invoke(int arg)
            => _option is null ? null : MaybeBuilder.Bind(_option.Value, new ResultReturn(arg));
    }
}