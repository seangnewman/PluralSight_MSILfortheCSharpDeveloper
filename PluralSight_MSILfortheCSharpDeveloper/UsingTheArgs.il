.class private auto ansi beforefieldinit SampleApplication.Program
	extends [mscorlib]System.Object
{
	// Methods
	.method private hidebysig static 
		void Main (
			string[] args
		) cil managed 
	{
		// Method begins at RVA 0x2050
		// Code size 23 (0x17)
		.maxstack 3
		.entrypoint
		.locals init (
			[0] string nameString
		)

		IL_0000: nop
		IL_0001: ldstr "Hello my name is "
		IL_0006: ldarg.0
		IL_0007: ldc.i4.0
		IL_0008: ldelem.ref
		IL_0009: call string [mscorlib]System.String::Concat(string, string)
		IL_000e: stloc.0
		IL_000f: ldloc.0
		IL_0010: call void [mscorlib]System.Console::WriteLine(string)
		IL_0015: nop
		IL_0016: ret
	} // end of method Program::Main

	.method private hidebysig static 
		void Greet (
			string name
		) cil managed 
	{
		// Method begins at RVA 0x2073
		// Code size 19 (0x13)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldstr "Greetings "
		IL_0006: ldarg.0
		IL_0007: call string [mscorlib]System.String::Concat(string, string)
		IL_000c: call void [mscorlib]System.Console::WriteLine(string)
		IL_0011: nop
		IL_0012: ret
	} // end of method Program::Greet

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x2087
		// Code size 8 (0x8)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [mscorlib]System.Object::.ctor()
		IL_0006: nop
		IL_0007: ret
	} // end of method Program::.ctor

} // end of class SampleApplication.Program
