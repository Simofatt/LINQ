using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TCPData
{
    public static  class Data
    {
        public static List<Employe> GetEmployees()
        {
            List<Employe> employees = new List<Employe>();
            Employe employe = new Employe()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                AnnualSalary = 10000.2m,
                IsManager = true,
                DepartementId = 1
            };
            employees.Add(employe);
            employe = new Employe()
            {
                Id = 2,
                FirstName = "Mohamed",
                LastName = "Fatehi",
                AnnualSalary = 1200.22m,
                IsManager = false,
                DepartementId = 2
            };
            employees.Add(employe);
        
            return employees;
            }


        public static List<Departement> GetDepartements()
        {
            List<Departement> departements = new List<Departement>();
            Departement departement = new Departement()
            {
                Id = 1,
                ShortName = "IT",
                LongName = "Technologie"

            };
            departements.Add(departement);
            departement = new Departement()
            {
                Id = 2,
                ShortName = "Supply chain",
                LongName = "SCM"

            };
            departements.Add(departement);
            departement = new Departement()
            {
                Id = 3,
                ShortName = "Reseau",
                LongName = "GSTR"

            };
            departements.Add(departement);
            return departements;
        }

             }
}
