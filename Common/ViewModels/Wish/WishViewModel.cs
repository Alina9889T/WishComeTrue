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
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [Display(Name = "FulFilled")]
        public bool FulFilled { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(Name, "Please fill the name");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentNullException(Description, "Please fill the desccription");
            }

            if (string.IsNullOrWhiteSpace(Link))
            {
                throw new ArgumentNullException(Link, "Please fill the link");
            }
        }
    }
}
