using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToLinQ
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public List<string> Hobbies { get; set; }
        public override string ToString()
        {
            return string.Format($"{Id},{Name},{Degree},{Hobbies}");
        }

    }

    class JSonParserEx
    {
        static void Main()
        {
            Student student = new Student() 
            { 
                Id=1,
                Name="Srikanth",
                Degree ="BTech",
                Hobbies=new List<string>
                {
                    "Reading",
                    "Playing Games"
                }
            };
           string s=JsonConvert.SerializeObject(student);
            //Console.WriteLine(s);
            File.WriteAllText(@"student.json", s);
            Console.WriteLine("Stored");

            string ds = String.Empty;
            ds = File.ReadAllText(@"student.json");
          Student rs=  JsonConvert.DeserializeObject<Student>(ds);
            Console.WriteLine(rs);
        }
    }
}
