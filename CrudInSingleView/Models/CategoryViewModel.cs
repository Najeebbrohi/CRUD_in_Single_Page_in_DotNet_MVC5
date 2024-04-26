using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudInSingleView.Models
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}