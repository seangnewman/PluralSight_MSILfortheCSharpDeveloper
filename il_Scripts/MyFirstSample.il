.assembly extern mscorlib {}
.assembly MyFirstSample {}

.method static public void main() cil managed
{
    .maxstack 1
    .entrypoint
    
    ldstr "My name is Sean"
    
    call void [mscorlib]System.Console::WriteLine (class System.String)
    ret
}