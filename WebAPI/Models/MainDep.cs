using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MainDep
    {
        [Key]
        public int MainDepID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string NameAR { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public String Creator { get; set; }
        public List<Department>  DepartmentList { get; set; }
        


    }
}
