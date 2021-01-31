using System;
using System.Reflection;
using System.Reflection.Emit;

namespace CreatingAType
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
                                                                                                                        new AssemblyName("Demo"), 
                                                                                                                         AssemblyBuilderAccess.Run);

            var moduleBuiler = assemblyBuilder.DefineDynamicModule("PersonModule");

            // Create a person class
            var typeBuilder = moduleBuiler.DefineType("Person", TypeAttributes.Public);
            //create a field
            var nameField = typeBuilder.DefineField("name", typeof(string), FieldAttributes.Private);
            // Define constuctor with one parameter
            var ctor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new[] { typeof(string)});

            var ctorIL = ctor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);                       // First parameter to a constructor is a reference to itself...sort of like using this
            ctorIL.Emit(OpCodes.Ldarg_1);                       // The 1st parameter passed to the constructor
            ctorIL.Emit(OpCodes.Stfld, nameField);       // Stores value in name field
            ctorIL.Emit(OpCodes.Ret);

            // Define property to access name
            var nameProperty = typeBuilder.DefineProperty("Name",
                                                                                                            PropertyAttributes.HasDefault,
                                                                                                            typeof(string),
                                                                                                            null                            // Has no parameters
                                                                                                            );
            var namePropertyGetMethod = typeBuilder.DefineMethod("get_Name",
                                                                                                                                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                                                                                                                                typeof(string),
                                                                                                                                Type.EmptyTypes);

            nameProperty.SetGetMethod(namePropertyGetMethod);

            var namePropertyGetMethodIL = namePropertyGetMethod.GetILGenerator();

            namePropertyGetMethodIL.Emit(OpCodes.Ldarg_0);          // Get instance to class
            namePropertyGetMethodIL.Emit(OpCodes.Ldfld, nameField);
            namePropertyGetMethodIL.Emit(OpCodes.Ret);

            var t = typeBuilder.CreateType();

            var nProperty = t.GetProperty("Name");

            var instance = Activator.CreateInstance(t, "Sean");
            var result = nProperty.GetValue(instance, null);
            Console.WriteLine(result);


        }
    }
}
