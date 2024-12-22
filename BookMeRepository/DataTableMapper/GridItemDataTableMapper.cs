using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeRepository.DataTableMapper
{
    public class GridItemDataTableMapper
    {
        public int id { get; set; }
        public string name { get; set; }

        public string location { get; set; }

        [Range(0, 5, ErrorMessage = "rating must be between 0 and 5")]
        public float rating { get; set; }

        public string imageUrl { get; set; }

        //public DateTime? dateofTravel { get; set; }
        public string[] datesOfTravel { get; set; }

        public string boardBasis { get; set; }

        public room[] rooms { get; set; }


    }

    public class room
    {
        public int amount { get; set; }
        public string roomType { get; set; }
        public int roomid { get; set; }

    }


}
