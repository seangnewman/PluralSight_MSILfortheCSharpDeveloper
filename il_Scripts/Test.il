//Test.IL
//A simple programme which prints a string on the console

.assembly extern mscorlib {}

.assembly Test
{
    .ver 1:0:1:0
}
.module test.exe

.method static void main() cil managed
{
    .maxstack 1
    .entrypoint
    
    ldstr "I am from the IL Assembly Language..."
    
    call void [mscorlib]System.Console::WriteLine (string)
    ret
}