using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\files\");
            var result = new List<string>();

            foreach (var file in files)
            {
                 var bytes = File.ReadAllBytes(file);
                
                    var enc = new UTF8Encoding(true);
                    var preamble = enc.GetPreamble();

                if (preamble.Where((p, i) => p != bytes[i]).Any())
                {
                    result.Add(file);
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
