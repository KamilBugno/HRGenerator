using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGenerator
{
    class Generator
    {
        private Random random;
        private List<string> snNumbers;
        private List<string> imeiNumbers;

        public Generator()
        {
            random = new Random();
            snNumbers = new List<string>();
            imeiNumbers = new List<string>();
        }

        public List<Person> Generate()
        {
            var people = new List<Person>();

            for(int i = ConstantData.startKey; i < ConstantData.startKey + ConstantData.numberOfPeople; i++)
            {
                var _key = i.ToString();
                var name = GenerateName();
                var surname = GenerateSurname();
                var department = GenerateDepartment();
                var officialMail = GenerateOfficialMail(name, surname);
                var devices = GenerateDevices();
                var roles = GenerateRoles(department);

                var person = new Person()
                {
                    _key = _key,
                    name = name,
                    surname = surname,
                    department = department,
                    official_mail = officialMail,
                    devices = devices,
                    roles = roles
                };

                people.Add(person);
            }
            return people;
        }

        private Roles[] GenerateRoles(string department)
        {
            var numberOfRoles = random.Next(1, 3);
            var roles = new Roles[numberOfRoles];

            for (int i = 0; i < numberOfRoles; i++)
            {
                var title = GenerateTitle(department);
                var start_date = GenerateDate();
                roles[i] = new Roles()
                {
                    title = title,
                    start_date = start_date
                };
            }

            return roles;
        }

        private string GenerateDate()
        {
            var year = random.Next(2000, 2019);
            var month = random.Next(1, 13);
            var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            var hour = random.Next(0, 24);
            var minute = random.Next(0, 60);
            var second = random.Next(0, 60);
            var date = new DateTime(year, month, day, hour, minute, second);
            return DateToString(date);
        }

        public string DateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.000");
        }

        private string GenerateTitle(string department)
        {
            var roles = ConstantData.departmentsRoles[department];
            return DrawFromArray(roles);
        }

        private Devices GenerateDevices()
        {
            var phones = GeneratePhones();
            var computers = GenerateComputers();
            var devices = new Devices()
            {
                phone = phones,
                computer = computers
            };
            return devices;
        }

        private Computer[] GenerateComputers()
        {
            var numberOfComputers = random.Next(1, 3);
            var computers = new Computer[numberOfComputers];
            for(int i = 0; i < numberOfComputers; i++)
            {
                var sn = GenerateSN();
                var initial_date = GenerateDate();
                var end_date = GenerateLaterDateThan(initial_date);
                computers[i] = new Computer()
                {
                    SN = sn,
                    initial_date = initial_date,
                    end_date = end_date
                };
            }

            return computers;
        }

        private string GenerateLaterDateThan(string initial_date)
        {
            var initialDateTime = DateTime.ParseExact(initial_date, "yyyy-MM-ddTHH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            var year = random.Next(initialDateTime.Year, 2020);
            var month = random.Next(1, 13);
            var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            var hour = random.Next(0, 24);
            var minute = random.Next(0, 60);
            var second = random.Next(0, 60);
            var date = new DateTime(year, month, day, hour, minute, second);
            return DateToString(date);

        }

        private string GenerateSN()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string sn;
            do
            {
                sn = new string(Enumerable.Repeat(chars, 19)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

            } while (snNumbers.Contains(sn));

            snNumbers.Add(sn);

            return sn;
        }

        private Phones[] GeneratePhones()
        {
            var numberOfPhones = random.Next(1, 3);
            var phones = new Phones[numberOfPhones];
            for (int i = 0; i < numberOfPhones; i++)
            {
                var sn = GenerateSN();
                var imei = GenerateImei();
                var initial_date = GenerateDate();
                var end_date = GenerateLaterDateThan(initial_date);
                phones[i] = new Phones()
                {
                    SN = sn,
                    IMEI_number = imei,
                    initial_date = initial_date,
                    end_date = end_date
                };
            }

            return phones;
        }

        private string GenerateImei()
        {
            string imei = "";
            do
            {
                for (int i = 0; i < 15; i++)
                {
                    imei += random.Next(0, 10);
                }
            } while (imeiNumbers.Contains(imei));

            imeiNumbers.Add(imei);
            return imei;
        }

        private string GenerateOfficialMail(string name, string surname)
        {
            return name + "." + surname + "@company.com";
        }

        private string GenerateDepartment()
        {
            return DrawFromArray(ConstantData.departments);
        }

        private string GenerateSurname()
        {
            return DrawFromArray(ConstantData.surnames);
        }

        private string GenerateName()
        {
            return DrawFromArray(ConstantData.names);
        }

        private string DrawFromArray(string[] array)
        {
            var maxValue = array.Length;
            var anyArrayIndex = random.Next(maxValue);
            return array[anyArrayIndex];
        }
    }
}
