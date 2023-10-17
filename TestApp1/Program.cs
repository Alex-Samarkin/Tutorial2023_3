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
            items.Seq(0, 0.1, 1000000);
            items.RandomDouble(0,10,1000000);

            Console.WriteLine(items.ToLongString(20,20));

            Console.WriteLine(items.TableFirstN(12));
            Console.WriteLine();
            Console.WriteLine(items.TableLastN(12));

            Console.WriteLine(items.Table(12));

            Head head = new Head();
            Console.WriteLine(head);

            Console.WriteLine(person);

            Column column = new Column();
            column.Head = head;
            column.Items = items;
            Console.WriteLine( column.ToString() );

            Console.WriteLine();
            Console.WriteLine(column.Items.Plot(0,100));

            Console.WriteLine(items.Sum());
            Console.WriteLine(items.Mean());

            ScreenTable table = new ScreenTable();

            table.Add("Items count", items.Values.Count);
            table.Add("Sum", items.Sum());
            table.Add("Mean", items.Mean());
            table.Add("Var", items.Variance());
            table.Add("SD", items.SD());
            table.Add("Min", items.Min());
            table.Add("Max", items.Max());
            table.Add("Median", items.Median());
            table.Add("L Quartil", items.LQ());
            table.Add("U Quartil", items.UQ());

            Console.WriteLine(table);

            Histogram histogram = new Histogram();
            histogram.Construct(items);
            Console.WriteLine(histogram);

            items.RandomNormal(1000000);
            histogram.Construct(items);
            Console.WriteLine(histogram);

           

            Console.ReadLine();
        }
    }
}
