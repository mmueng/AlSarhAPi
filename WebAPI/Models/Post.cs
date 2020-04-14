using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string TitleAR { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }
        public String Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

      
        // Cover photo For post
        //public int PhotoID { get; set; }

        //  List<Photo> CategoriesList { get; set; }
        
        public int CategoryID { get; set; }
        public Category PostToCategory { get; set; }

        public int DepID { get; set; }

        public Department PostToDep { get; set; }

        public int MainDepID { get; set; }

        public MainDep PostToMainDep { get; set; }
    }
}
