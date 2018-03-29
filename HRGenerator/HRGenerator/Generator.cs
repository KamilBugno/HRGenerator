using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRGenerator
{
    class Generator
    {
        public Person Generate()
        {
            for(int i = ConstantData.startKey; i < ConstantData.numberOfPeople; i++)
            {
                var name = GenerateName();

            }
            return null;
        }
    }
}
