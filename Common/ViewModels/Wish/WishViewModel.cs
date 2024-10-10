using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishComeTrue.Common.ViewModels.Wish
{
    public class WishViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Wish")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Display(Name = "Created")]
        public string Created { get; set; }

        [Display(Name = "FulFilled")]
        public string FulFilled { get; set; }
    }
}
