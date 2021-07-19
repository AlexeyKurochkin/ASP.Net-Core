using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mentoring.Models
{
    public class Category
    {
	    public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
//        [JsonIgnore]
        public byte[] Picture { get; set; }

        [JsonIgnore]
		public virtual ICollection<Product> Products { get; set; }
    }
}
