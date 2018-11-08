using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Models
{
    public class Sport
    {
        [Key]
        public int SportID { get; set; }
        public string SportName { get; set; }

    }
}
