using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complain_System.Models
{
    public class ComplainBox
    {
        public int Id { get; set; }
        public string ComplainTitle { get; set; }
        public string Description { get; set; }
        public DateTime ComplainDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime Reminder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
