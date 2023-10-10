using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1;

namespace TestApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() 
                    { FirstName = "Ivan",
                      MiddleName ="Ivanovitch",
                      LastName="Ivanov",
                      // Почему new?
                      BirtDate = new DateTime(1990,5,22)
                    };
            Items items = new Items();
            items.Fill(0, 1000000);

            Console.WriteLine(person);

            Console.ReadLine();
        }
    }
}
