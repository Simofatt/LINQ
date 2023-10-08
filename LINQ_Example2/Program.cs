using System;
using System.Linq;

namespace LINQ_Example2
{

    class Program
    {
        public static void Main(String[] args)
        {
            int[] sum ;
            sum = new int[10] ;
            List<Employe> Employees = Data.GetEmployees();
            List<Departement> Departements = Data.GetDepartements();
            //************************************ ORDER OPERATORS *************************************//

            //METHOD SYNTAX 
            var results = Employees.Join(Departements, e => e.DepartementId, d => d.Id,
                (emp, dept) => new
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    AnnualSalary = emp.AnnualSalary,
                    DepartementName = dept.LongName,
                    DepartementId = dept.Id
                }
                ).OrderByDescending(o => o.Id).ThenByDescending(o => o.AnnualSalary);

            foreach (var emp in results)
            {
                Console.WriteLine("EMPLOYE : " + emp);
            }



            //QUERY SYNTAX 
            var results2 = from emp in Employees
                           join dept in Departements
                           on emp.DepartementId equals dept.Id
                           orderby emp.DepartementId descending, emp.AnnualSalary descending

                           select new
                           {
                               Id = emp.Id,
                               FirstName = emp.FirstName,
                               LastName = emp.LastName,
                               AnnualSalary = emp.AnnualSalary,
                               DepartementName = dept.LongName,
                               DepartementId = dept.Id
                           };
            foreach (var res in results2)
            {
                Console.WriteLine("EMPLOYE : " + res);
            }




            //******************************** GROUP BY OPERATORS ********************************    // 



            var results3 = from emp in Employees
                           group emp by emp.DepartementId;
            foreach (var res in results3)
            {
                Console.WriteLine("DEPARTEMENT ID : " + res.Key);
                Console.WriteLine("EMPLOYES IN THAT DEPARTEMENT ");
                foreach (var emp in res)
                {
                    Console.WriteLine(emp.FirstName);
                }
            }


            //******************************** QUANTIFIER OPERATORS  ********************************    // 


            //ANY & ALL 
            var annualSalaryComparaison = 10000;
            bool isTrueAll = Employees.All(e => e.AnnualSalary >= annualSalaryComparaison);
            if (isTrueAll)
            {
                Console.WriteLine("All employes have a salary above 10000");

            } else
            {
                Console.WriteLine("Not All employes have a salary above 10000");
            }

            bool isTrueAny = Employees.Any(e => e.AnnualSalary >= annualSalaryComparaison);
            if (isTrueAll)
            {
                Console.WriteLine("Some of the employes have a salary above 10000");
            }
            else
            {
                Console.WriteLine(" no pne  have a salary above 10000");
            }

            //CONTAINS 
            var EmployeSearch = new Employe
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Bahir",
                AnnualSalary = 10000.2m,
                IsManager = true,
                DepartementId = 1
            };

            bool isTrueContains = Employees.Contains(EmployeSearch, new EmployeComparer());
            if (isTrueContains)
            {
                Console.WriteLine("Employe list contains EmployeSearch");
            }
            else
            {
                Console.WriteLine("Employe list doesn't contains EmployeSearch");
            }
            //COMPARE : 

            var EmployesComparer = Data.GetEmployees();

            bool isEqual = Employees.SequenceEqual(EmployesComparer, new EmployeComparer());

            Console.WriteLine($"RESULT : {isEqual}");

            //CONCATENATE   IT HAVE TO BE THE SAME TYPE 
            var Concatenate = Employees.Concat(EmployesComparer);
            foreach (var conc in Concatenate)
            {
                Console.WriteLine($"RESULT CONCATENATION : {conc.FirstName}");
            }

            //AGGREGATE : 
            decimal totalAnnualSalary = Employees.Aggregate<Employe, decimal>(0, (totalAnnualSalary, e) =>
            {
                var bonus = (e.IsManager) ? 0.04m : 0.02m;
                totalAnnualSalary = (e.AnnualSalary + (e.AnnualSalary * bonus)) + totalAnnualSalary;
                return totalAnnualSalary;

            });

            Console.WriteLine($"TOTAL ANNUAL SALARY OF ALL EMPLOYES (INCLUDING BONUSES) : {totalAnnualSalary}");


            string data = Employees.Aggregate<Employe, string>("Annual salary of each emmploye is [including bonuses] : ", (s, e) =>
            {
                var bonus = (e.IsManager) ? 0.04m : 0.02m;

                s += $"  {e.FirstName} -- {(e.AnnualSalary + (e.AnnualSalary * bonus))}";
                return s;

            });
            Console.WriteLine(data);

            //AVERAGE :
            var average = Employees.Average(e => e.AnnualSalary);
            Console.WriteLine($"AVERAGE SALARY IS : {average}");

            var averageChain = Employees.Where(e => e.DepartementId == 1).Average(e => e.AnnualSalary);
            Console.WriteLine($"AVERAGE SALARY in IT is : {averageChain}");

            var averageSalaryIT = Employees
                                .Join(Departements, e => e.DepartementId, d => d.Id, (e, d) => new { Employee = e, Department = d })
                                .Where(x => x.Department.ShortName == "IT")
                                .Average(x => x.Employee.AnnualSalary);

            Console.WriteLine($"Average Salary in IT is: {averageSalaryIT}");


            //COUNT 
            var count = EmployesComparer.Count(e => e.DepartementId == 1);
            Console.WriteLine($"Number of employes in It is : {count}");

            //SUM 
            var sum2= Employees.Where(e => e.DepartementId == 1).Sum(e => e.AnnualSalary);
            Console.WriteLine($"Sum of the salary  employes in It is : {count}");

            //SKIP WHILE  
            var skip = Employees.SkipWhile(e => e.Id == 1);
            foreach (var item in skip) {
                Console.WriteLine($"The skiped employes : {item.FirstName}");
            }







            //******************************* ELEMENT OPERATORS *************************************//
            var result5 = Employees.ElementAtOrDefault(0);
            var result6 = Employees.FirstOrDefault();
            var result7 = Employees.LastOrDefault();
            var result8 = Employees.SingleOrDefault(e => e.Id == 1);
            if (result5 != null)
            {
                Console.WriteLine("ELEMENT AT index 1 : " + result5.FirstName);
            } else
            {
                Console.WriteLine("THERE IS NO ELEMENT AT THE INDEX 1");
            }
            if (result6 != null)
            {
                Console.WriteLine("NAME OF FIRST  ELEMENT IS : " + result6.FirstName);
            } else { Console.WriteLine("THERE IS NO ELEMENT AT THE INDEX 1"); }


            Console.ReadKey();
        }













        public class Departement
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
            public string LongName { get; set; }
        }
        public class Employe
        {
            public int? Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public decimal AnnualSalary { get; set; }
            public bool IsManager { get; set; }
            public int DepartementId { get; set; }
        }
        public static class Data
        {
            public static List<Employe> GetEmployees()
            {
                List<Employe> employees = new List<Employe>();
                Employe employe = new Employe()
                {
                    Id = 1,
                    FirstName = "Ahmed",
                    LastName = "Bahir",
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
                employe = new Employe()
                {
                    Id = 3,
                    FirstName = "Khalid",
                    LastName = "Matir",
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

      
        public class EmployeComparer : IEqualityComparer<Employe>
        {
            bool IEqualityComparer<Employe>.Equals(Employe? x, Employe? y)
            {
                if(x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName)
                {
                    return true;
                }
                return false;
            }

            int IEqualityComparer<Employe>.GetHashCode(Employe obj)
            {
                return obj.Id.GetHashCode();
                }
        }
    }
}