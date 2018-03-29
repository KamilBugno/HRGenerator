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
            var person = new Person();
            person._key = "1";
            person.name = "Jan";
            person.surname = "Kowalski";
            person.department = "Software Department";
            person.official_mail = "jan.kowalski@company.com";
            person.devices = new Devices();
            person.devices.computer = new Computer[1];
            person.devices.computer[0] = new Computer()
            {
                    SN = "123",
                    end_date = "2016-03-03T08:02:49.321",
                    initial_date = "2015-03-03T08:02:49.321"
            };
            person.devices.phone = new Phones[1];
            person.devices.phone[0] = new Phones()
            {
                SN = "321",
                IMEI_number = "2222",
                end_date = "2016-03-03T08:02:49.321",
                initial_date = "2015-03-03T08:02:49.321"
            };
            person.roles = new Roles[1];
            person.roles[0] = new Roles()
            {
                title = "C# developer",
                start_date = "2015-03-03T08:02:49.321"
            };
            string output = JsonConvert.SerializeObject(person);
            Console.WriteLine(output);
            File.WriteAllText("test.txt", output);
            Console.ReadKey();
        }
    }
}
