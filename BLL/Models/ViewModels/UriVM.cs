using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ViewModels
{
    public class UrlVM
    {
        [Required]
        [Url]
        [Display(Name = "Original URL")]
        public string OriginalUrl { get; set; }
    }
}
