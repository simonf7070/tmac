using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using tmac.Validation;

namespace tmac.Models
{
    public class NetworkAsset
    {
        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(1000)]
        public string Description { get; set; }
        
        [Required]
        [DisplayName("IP Address")]
        [IpAddress]
        public string IpAddress { get; set; }

        public SelectList TypeSelectList = new SelectList(
            new List<SelectListItem>
            {
                new SelectListItem { Text = "Computer", Value = "Computer" },
                new SelectListItem { Text = "Server", Value = "Server" },
                new SelectListItem { Text = "Laptop", Value = "Laptop" }
            }, "Value", "Text");
    }
}