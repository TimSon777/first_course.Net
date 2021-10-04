.class public abstract sealed auto ansi beforefieldinit hw2_il.ErrorMessages extends System.Object
{
    .method public hidebysig static bool IsErrorCodeDisplayErrorMessage(
        valuetype hw2_il.ErrorCode code, string[] args) cil managed
    {
        .maxstack 5
        
        ldarg.0
        ldc.i4.0
        ceq
        brtrue.s return_false
        br.s check_code_1
        
        check_code_1: ldarg.0
        ldc.i4.1
        ceq
        brtrue.s write_message_with_code_1
        br.s check_code_2 
        
        check_code_2: ldarg.0
        ldc.i4.2
        ceq
        brtrue.s write_message_with_code_2
        br.s write_message_with_code_3
        
        write_message_with_code_1: ldstr "The program requires 3 arguments, but was {0}"
        ldarg.1   
        ldlen
        box [System.Runtime]System.Int32
        call string System.String::Format(string, object)
        call void [System.Console]System.Console::WriteLine(string)
        br.s return_true
        
        write_message_with_code_2: ldstr "Value(s) is/are not int: "
        ldarg.1     
        ldc.i4.0
        ldelem.ref
        ldstr ", "
        ldarg.1     
        ldc.i4.2
        ldelem.ref
        call string System.String::Concat(string, string, string, string)
        call void [System.Console]System.Console::WriteLine(string)   
        br.s return_true
        
        write_message_with_code_3: ldstr "Value is not operation: "
        ldarg.1     
        ldc.i4.1
        ldelem.ref
        call string System.String::Concat(string, string)
        call void [System.Console]System.Console::WriteLine(string)  
        br.s return_true
        
        return_false: ldc.i4.0 ret
        return_true: ldc.i4.1 ret
    } 
}

