using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Entity;

namespace WishComeTrue.Common.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        public string Name { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(Name, "Please fill the name");
            }
        }
    }
}
