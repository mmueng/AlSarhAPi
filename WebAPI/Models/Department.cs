using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Department
    {
        [Key]
        public int DepID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string NameAR { get; set; }
        
        public string Description { get; set; }
        public string DescriptionAR { get; set; }
        public String Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Category> CategoriesList { get; set; }

        public  List<Post> DepPostList { get; set; }

        [ForeignKey(nameof(CurrMainDepID))]
        public int CurrMainDepID { get; set; }

        public MainDep CurrMainDep { get; set; }


    }
}
