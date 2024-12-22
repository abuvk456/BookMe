using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeModel
{
    public class GridItem
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string location { get; set; }
       
        [Range(0, 5, ErrorMessage = "rating must be between 0 and 5")]
        public float rating { get; set; }

        public string ImageUrl { get; set; }

        //public DateTime? DateofTravel { get; set; }
        public string[] datesOfTravel { get; set; }
        public string DateofTravel { get; set; }

        public string BoardBasis { get; set; }

        public roomdetails[] rooms { get; set; }


    }
    public class roomdetails
    {
        public string RoomType { get; set; }
        public int amount { get; set; }

        public int roomid { get; set; }

    }
}
