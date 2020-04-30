using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ViewModel
    {
        // MainDep Model
        public MainDep NewMainDep { get; set; }
        public List<MainDep> AllMainDep { get; set; }
        // Department Model
        public Department NewDepartment { get; set; }
        public List<Department> AllDepartments { get; set; }
        // Category Model
        public Category NewCategory { get; set; }
        public List<Category> AllCategories { get; set; }
        // Post Model
        public Post NewPost { get; set; }
        public List<Post> AllPosts { get; set; }

        public Photo NewPhoto { get; set; }
        public List<Photo> AllPhotos { get; set; }
    }
}
