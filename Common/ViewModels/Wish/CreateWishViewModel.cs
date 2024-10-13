using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishComeTrue.Common.ViewModels.Wish
{
    public class CreateWishViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
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

    public class DeleteWishViewModel
    {
        public string Id { get; set; }
    }
}
