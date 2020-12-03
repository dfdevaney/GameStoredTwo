using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoredTwo.Models.Publisher
{
    public class PublisherDetail
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
        public List<PublisherListOfGames> PublisherGames { get; set; }
    }
}
