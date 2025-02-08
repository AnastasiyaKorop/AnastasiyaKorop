using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricAuthApp.Models
{
    public class ClientEmployeeConnection
    {
        public int Id {  get; set; }
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
    }
}
