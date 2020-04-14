using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public String Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int DepID { get; set; }

        public Department CategToDep { get; set; }
        public int MainDepID { get; set; }

        public List<Post> CategPostList { get; set; }


    }
}
