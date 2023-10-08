using System;
using System.Collections.Generic;
using System.Text;

namespace TCPData
{
    public class Employe
    {
        public int? Id { get; set; }  
        public string? FirstName { get; set; }    
        public string? LastName { get; set; }
        public decimal? AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartementId { get; set; }
    }
}
