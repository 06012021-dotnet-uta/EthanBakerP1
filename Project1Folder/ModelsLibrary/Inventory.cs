using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }

        public Locations Location { get; set; }

        public Products Product { get; set; }

        [Required]
        public int InventoryAmount { get; set; }
    }
}
