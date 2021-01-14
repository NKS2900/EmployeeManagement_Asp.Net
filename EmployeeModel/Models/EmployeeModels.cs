using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeModel.Models
{
    [Table("EmployeeTable")]
    public class EmployeeModels
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public long Contact { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
