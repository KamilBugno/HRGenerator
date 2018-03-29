using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();
            var people = generator.Generate();

            string json = "";

            foreach(Person person in people)
            {
                json += JsonConvert.SerializeObject(person);
                json += "," + Environment.NewLine;
            }
            File.WriteAllText("test2.txt", json);
        }
    }
}
