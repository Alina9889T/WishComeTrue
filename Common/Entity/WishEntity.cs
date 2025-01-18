using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishComeTrue.Common.Entity
{
    public class WishEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime Created { get; set; }
        public bool FulFilled { get; set; }
        public int? CategoryId { get; set; }
        public CategoryEntity Category {  get; set; }
    }
}
