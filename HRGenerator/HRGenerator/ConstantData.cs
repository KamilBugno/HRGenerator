using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGenerator
{
    class ConstantData
    {
        public static int startKey = 100;
        public static int numberOfPeople = 10;
        public static string[] departments = { "Software Development", "Sales Department",
            "Accounts Department", "Quality Assurance", "Executive Department"};
        public static string[] rolesForSofrwareDevelopment = { "Internship", "Junior C# Developer",
            "Regular C# Developer", "Senior C# Developer", "Frontend Developer", "Database Administrator"};
        public static string[] rolesForSalesDepartment = { "Junior Sales Officer", "Senior Sales Officer"};
        public static string[] rolesForAccountsDepartment = { "Junior Account", "Regular Account",
            "Senior Account"};
        public static string[] rolesForQualityAssurance = { "Junior Web Tester", "Senior Web Tester"};
        public static string[] rolesForExecutiveDepartment = { "Team Leader", "Manager", "Head Department"};
        public static Dictionary<string, string[]> departmentsRoles = new Dictionary<string, string[]>()
        {
            {"Software Development", rolesForSofrwareDevelopment},
            {"Sales Department", rolesForSalesDepartment},
            {"Accounts Department", rolesForAccountsDepartment},
            {"Quality Assurance", rolesForQualityAssurance},
            {"Executive Department", rolesForExecutiveDepartment}
        };
        public static string[] names = { "Amelia", "Olivia", "Emily", "Ava", "Isla", "Jessica",
            "Poppy", "Isabella", "Sophie", "Mia", "Ruby", "Lily", "Grace", "Evie", "Sophia",
            "Ella", "Scarlet", "Chloe", "Isabelle", "Freva", "Olivier", "Jack", "Harry", "Jacob",
            "Charlie", "Thomas", "Oscar", "William", "James", "George", "Alfie", "Joshua",
            "Noah", "Ethan", "Muhammad", "Archie", "Leo", "Henry", "Joseph", "Samuel"
        };
        public static string[] surnames = { "Harlow", "Harrington", "Hartford", "Hastings",
            "Hayden", "Hayes", "Hayhurst", "Hayley", "Holton", "Home", "Hornsby", "Huckabee",
            "Reid", "Remington", "Richmond", "Compton", "Coombs", "Copeland", "Bentham",
            "Bentley", "Berkeley", "Ainsworth", "Alby", "Allerton", "Fawcett", "Fulton",
            "Oakes", "Oakley", "Ogden", "Paxton", "Payton", "Perry", "Stansfield", "Stanton"
        };
    }
}
