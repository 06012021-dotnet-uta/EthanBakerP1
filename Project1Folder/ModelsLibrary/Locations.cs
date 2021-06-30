using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Locations
    {
		[Key]
		public int LocationID { get; set; }
		[Required]
		[MaxLength(50)]
		[Display(Name = "Location Name")]
		public string LocationName { get; set; }

	}
}
