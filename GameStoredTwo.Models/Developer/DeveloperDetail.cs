using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Developer
{
    public class DeveloperDetail
    {
        public int DeveloperID { get; set; }
        public string DeveloperName { get; set; }
        public List<DeveloperListOfGames> DeveloperGames { get; set; }
    }
}
