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
        public int Id { get; set; }
        public string ImgPath { get; set; }


        [ForeignKey(nameof(CurrPostID))]
        public int CurrPostID { get; set; }
        public Post CurrPost { get; set; }



      //  [Required]
       // public string Name { get; set; }

      //  [Required]
       // public string Address { get; set; }
    }
}
