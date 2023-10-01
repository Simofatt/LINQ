using TCPData;

using TCPExtensions;

namespace Linq
{
    class Program
    {
         static void Main(string[] args)
        {
            List<Employe> employees = Data.GetEmployees();
            List<Departement> departements = Data.GetDepartements();

            //**********************USING EXTENSION METHODS****************************** 
            var filtredEmployes = employees.Filter(emp => emp.IsManager == false);
            foreach( var emp in filtredEmployes)
            {
              Console.WriteLine("FIRST NAME : "   +emp.FirstName); 
            }
            Console.WriteLine();


            
           

            //********************************LINQ QUERY SYNTAX****************************
            var resultList = from emp in employees
                             join depart in departements
                             on emp.DepartementId equals depart.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 DepartementName = depart.LongName
                             };
            foreach (var result in resultList)
            {
                Console.WriteLine(result.FirstName);
                Console.WriteLine(result);

            }

            // ********************* (EXTENSIONS METHODS) METHOD SYNTAX :*******************
            var results2 = employees.Select(emp => new
            {
                FullName = emp.FirstName + "  " + emp.LastName,
                AnnualSalary = emp.AnnualSalary
            }).Where(emp => emp.AnnualSalary >= 5000);

            foreach (var item in results2)
            {
                Console.WriteLine(item.FullName + " => " + item.AnnualSalary);

            }


            //JOIN 
            var results = employees.Join(departements, e => e.DepartementId, d => d.Id,
               (emp, dept) => new
               {
                   Id = emp.Id,
                   FirstName = emp.FirstName,
                   LastName = emp.LastName,
                   AnnualSalary = emp.AnnualSalary,
                   DepartementName = dept.LongName,
                   DepartementId = dept.Id
               }
               );

            foreach (var emp in results)
            {
                Console.WriteLine("EMPLOYE : " + emp);
            }



            //BECAUSE LINQ SYNTAX DOESNT SUPPORT THAT SO WE USE EXTENSIONS METHODS SYNTAX 
            var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
            var highestAnnualSalary = resultList.Max(a=> a.AnnualSalary);
            var minSalary = resultList.Min(a => a.AnnualSalary);
            Console.WriteLine("HIGHEST SALARY IS :"+highestAnnualSalary);





            //*****************************DEFERRED EXECUTIONS : *********************************

           /* var resultList2 = from emp in employees
                             
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 
                             };
            Employe employeTest = new Employe()
            {
                Id= 3 ,
                FirstName="Khalid",
                LastName="Habib",
                AnnualSalary=80000.8m,
                DepartementId = 2
            };

            employees.Add(employeTest);
            foreach (var result in resultList2)
            {
                Console.WriteLine("Deffered execution : "+ result.FirstName);
                Console.WriteLine("Deffered execution : " + result);

            }*/

            //************************************IMMIDIATE EXECUTION : **********************************
            var resultList3 = (from emp in employees

                              select new
                              {
                                  FirstName = emp.FirstName,
                                  LastName = emp.LastName,
                                  AnnualSalary = emp.AnnualSalary,

                              }).ToList();
            Employe employeTest3 = new Employe()
            {
                Id = 3,
                FirstName = "Khalid",
                LastName = "Habib",
                AnnualSalary = 80000.8m,
                IsManager = false,
                DepartementId = 2
            };

            employees.Add(employeTest3);
            foreach (var result in resultList3)
            {
                Console.WriteLine("Immidiate execution : " + result.FirstName);
                Console.WriteLine("Immidiate execution : " + result);

            }



            //**************************** LEFT RIGHT JOIN ************************************** 
            //TO GROUP EVERY DEPARTEMENT WITH THE GROUP OF EMPLOYES THAT HE HAS 
            //AND TO SELECT THE EVERY DEPARTEMENTS EVEN IF THE CONDITION DOESNT MATCH (LEFT JOIN)
            var JoinResults = from dep in departements
                              join emp in employees
                              on dep.Id equals emp.DepartementId
                              into employeeGroup
                              select new
                              {
                                  Employees = employeeGroup,
                                  departementName = dep.LongName
                              };
            foreach(var res in JoinResults)
            {
                Console.WriteLine("DEPARTEMENT NAME : " + res.departementName);
                foreach (var emp in res.Employees)
                {
                    
                    Console.WriteLine(emp.FirstName+" "+emp.LastName);  
                }
            }



            Console.ReadKey();
        }
    }
}