using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportEvent.Models
{
    public class Tournament
    {
        [Key]
        public int TournamentID { get; set; }
        public string TournamentName{ get; set; }

        public int CountryID { get; set; }

        public int SportID { get; set; }

        public string SportName { get; set; }

        public string CountryName { get; set; }
    }
}
