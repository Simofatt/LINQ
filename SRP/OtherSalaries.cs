using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    internal class OtherSalaries : ISalary
    {
        //OCP ADDING ANOTHER FUNCTIONNALITY BY EXTENDING THE CLASS NOT MODIFYING IT 
        public int salary(string role, int salary, int bonus)
        {
            if (role == "Directeur")
            {
                bonus += 15; 
                return salary * bonus;
            }
            else if (role == "devs")
            {
                bonus += 5;
                return salary + bonus;
            }

            return 0;
        }
    }
}
