using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace JsonToLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
           
            StreamReader reader = File.OpenText(@"F:\DotNet 2021\ConsoleAssignments\JsonToLinQ\JsonToLinQ\example_2.json");

            JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

            string question = (string)o["quiz"]["sport"]["q1"]["question"];
            Console.WriteLine(question);
    JToken j=     o["quiz"]["sport"]["q1"]["options"];
            Console.WriteLine(j);
            IList<string> anwers = j.Select(c => (string)c).ToList();
            foreach (var i in anwers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("------------------");
            JToken j1 = o["quiz"];
         var i1=   j.Select(c => (string)c).Select(c => (String)c);
            foreach (var item in i1)
            {
                Console.WriteLine(item);
            }

            JToken j2 = o["quiz"]["maths"];
            var i2 = j2.Select(c => c);
            foreach (var item in i2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");
            var post = from p in o["quiz"]["maths"]["q1"].SelectMany(i => i).Values()
                       select p;
            foreach (var item in post)
            {
                Console.WriteLine(item);
            }
            var post1 = from p in o["quiz"]["sport"]["q1"].Children()
                       select p;
            foreach (var item in post1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------");
            var post2 = from p in o["quiz"]["sport"]["q1"].Ancestors().Last()
                        select p;
            foreach (var item in post2)
            {
                Console.WriteLine(item);
            }


        }
    }
}
