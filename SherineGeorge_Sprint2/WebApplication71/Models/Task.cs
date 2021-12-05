using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public class Task
    {

        public int Id { get; set; }
        public int ProjectID { get; set; }

        public int Status { get; set; }

        public int AssignedToUserID { get; set; }

        public string Detail { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
