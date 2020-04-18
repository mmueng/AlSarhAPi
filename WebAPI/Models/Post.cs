using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ImgPath { get; set; }

        public List<Photo> PhotoList { get; set; }

        [ForeignKey(nameof(CurrCategoryID))]
        public int CurrCategoryID { get; set; }
        public Category CurrCategory { get; set; }

        
        [ForeignKey(nameof(CurrDepID))]
        public int CurrDepID { get; set; }
        public Department CurrDepartment { get; set; }


        [ForeignKey(nameof(pMainDepID))]
        public int pMainDepID { get; set; }
        public MainDep CurrMainDep { get; set; }

    }
}
