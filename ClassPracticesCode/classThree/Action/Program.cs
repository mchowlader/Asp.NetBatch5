using System;

namespace Action
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = "Maria";
            var lastName = "Hupko";

            NamePrint(firstName, lastName, NameSet);
        }

        public static void NameSet(string nameOne, string nameTwo)
        {
            Console.WriteLine($"Given Name: {nameOne}, Surname: {nameTwo}");
        }

        public static void NamePrint(string firstName, string lastName, Action<string,string>item)
        {
            item(firstName, lastName);
        }
    }
}
