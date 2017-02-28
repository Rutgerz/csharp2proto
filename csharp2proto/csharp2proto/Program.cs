using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp2proto
{
    class Program
    {
        static void Main(string[] args)
        {
            A obj = new B();
            var aType = obj.GetType();
            foreach(var propType in aType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Where(x => x.CanRead))
            {
                Console.WriteLine($"{aType.Name}.{propType.Name} of type {propType.PropertyType}");
            }
            foreach (var fieldType in aType.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
            {
                Console.WriteLine($"{aType.Name}.{fieldType.Name} of type {fieldType.FieldType}");
            }

            Console.ReadLine();
        }

        public class A
        {
            public A self;
            public string Str { get; set; }
            public int Int { get; set; }
            public IList<double> DoubleList { get; set; }
            public IDictionary<int, IList<string>> DictIntStringList { get; set; }

            public static bool IsEvil { get; set; }
        }

        public class B : A
        {
            public C fruit;
            public float Float { get; set; }

            public static bool YaReally;
        }

        public struct C
        {
            bool apples;
            bool bananas;
        }
    }
}
