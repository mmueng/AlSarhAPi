using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string ImgPath { get; set; }

        [ForeignKey(nameof(CurPostID))]
       public int? CurPostID { get; set; }
       public Post CurrPost { get; set; }
        
        //  [Required]
        // public string Name { get; set; }

        //  [Required]
        // public string Address { get; set; }
    }
}
