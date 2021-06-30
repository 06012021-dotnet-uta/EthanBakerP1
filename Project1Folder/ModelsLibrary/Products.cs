using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Products
    {
		[Key]
		public int ProductID { get; set; }

		[Required]
		[MaxLength(20)]
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }

		[Required]
		[Display(Name = "Price")]
		public decimal ProductPrice { get; set; }

		[Required]
		[MaxLength(300)]
		[Display(Name = "Description")]
		public string ProductDescription { get; set; }
	}

}
