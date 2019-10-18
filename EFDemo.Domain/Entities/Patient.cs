using System;
using System.Collections.Generic;
using System.Text;

namespace EFDemo.Domain.Entities
{
   public class Patient       
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
    }
}
