using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP
{
    
    public class Salaries :ISalary
    {
        public int salary(string role, int salary, int bonus)
        {
            if (role == "manager")
            {
                return salary * bonus;
            }
            else if (role == "Cadre")
            {
                return salary + bonus;
            }

            return 0;
        }
    }
}
