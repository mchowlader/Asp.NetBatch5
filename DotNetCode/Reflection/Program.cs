using System;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Production);
            Type type2 = typeof(Pdoduct);

            var t1 = type.Name;
            var t2 = type.FullName;
            var t3 = type.IsClass;
            var t4 = type.IsAbstract;
            var t5 = type.IsVisible;
            var t6 = type.BaseType;
            //var t7 = type.DeclaringMethod; //errror
            var t8 = type.GetFields();
            var t9 = type.GetConstructors();
            var t10 = type.GetDefaultMembers(); //nothing show
            var t11 = type.AssemblyQualifiedName;
            var t12 = type.GetMembers();


            var m = type2.BaseType;
            var m2 = type2.GetEvents();

            Console.WriteLine(t11);

            foreach (var item in t12)
            {
                Console.WriteLine(item);
            }

        }
    }
}
