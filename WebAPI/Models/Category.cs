using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAR { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(DepID))]
        public int DepID { get; set; }
        public Department CurrDepartment { get; set; }

        [ForeignKey(nameof(MainDepID))]
        public int MainDepID { get; set; }
        public MainDep CurrMainDep { get; set; }

        public List<Post> CategPostList { get; set; }


    }
}
