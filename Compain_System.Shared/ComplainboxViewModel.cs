using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Compain_System.Shared
{
    public class ComplainboxViewModel
    {
        [Required]
        [Display(Name = "Complain Title")]
        public string ComplainTitle { get; set; }
        [Required]
        [Display(Name = "Complain Title")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [Display(Name = "Complain Date")]
        public DateTime ComplainDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        [Display(Name = "Reminder")]
        public DateTime Reminder { get; set; }
    }
}
