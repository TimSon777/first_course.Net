.class public abstract sealed auto ansi beforefieldinit hw2_il.Parser extends System.Object
{
    .method public hidebysig static valuetype hw2_il.ErrorCode ParseCalcArguments(
        string[] args,
        [out] int32& val1,
        [out] valuetype hw2_il.CalculatorOperation& operation,
        [out] int32& val2) cil managed
    {
        .maxstack 2

        ldarg.1 ldc.i4.0 stind.i4
        ldarg.3 ldc.i4.0 stind.i4
        ldarg.2 ldc.i4.0 stind.i1
        
        ldc.i4.1
        ldarg.0
        call bool hw2_il.Parser::CheckArgLength(string[])
        ceq 
        brtrue.s try_parse_first_int
        br.s return_1
        
        try_parse_first_int: ldarg.0     
        ldc.i4.0
        ldelem.ref
        ldarg.1      
        call bool [System.Runtime]System.Int32::TryParse(string, int32&)
        brtrue.s try_parse_second_int
        br.s return_2
        
        try_parse_second_int: ldarg.0     
        ldc.i4.2
        ldelem.ref
        ldarg.3    
        call bool [System.Runtime]System.Int32::TryParse(string, int32&)
        brtrue.s try_parse_operation
        br.s    return_2
        
        try_parse_operation: ldarg.0     
        ldc.i4.1
        ldelem.ref
        ldarg.2      
        call bool hw2_il.Parser::TryParseOperation(string, valuetype hw2_il.CalculatorOperation&)
        brtrue.s return_0
        br.s return_3
    
        return_0: ldc.i4.0 ret
        return_1: ldc.i4.1 ret
        return_2: ldc.i4.2 ret
        return_3: ldc.i4.3 ret
    } 
    
    .method private hidebysig static bool CheckArgLength(string[] 'array') cil managed
    {
        .maxstack 2
        ldarg.0 
        ldlen
        ldc.i4.3
        ceq
        ret
    }
    
    .method private hidebysig static bool TryParseOperation(
        string arg,
        [out] valuetype hw2_il.CalculatorOperation& operation
        ) cil managed
    {
        .maxstack 2
        
        ldarg.0 
        ldstr "+"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s assign_plus
        br.s minus
        
        assign_plus: ldarg.1 
        ldc.i4.1
        stind.i1
        br.s return_true
        
        minus: ldarg.0 
        ldstr "-"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s assign_minus
        br.s multiply
        
        assign_minus: ldarg.1
        ldc.i4.2
        stind.i1 
        br.s return_true
        
        multiply: ldarg.0 
        ldstr "*"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s assign_multiply
        br.s divide
        
        assign_multiply: ldarg.1
        ldc.i4.3
        stind.i1 
        br.s return_true
        
        divide: ldarg.0 
        ldstr "/"
        call bool [System.Runtime]System.String::op_Equality(string, string)
        brtrue.s assign_divide
        br.s return_false
        
        assign_divide: ldarg.1
        ldc.i4.4
        stind.i1 
        br.s return_true
        
        return_false: ldc.i4.0 ret
        return_true: ldc.i4.1 ret
    } 
}