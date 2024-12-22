using BookMeModel;
using BookMeRepository.DataTableMapper;
using BookMeRepository.IBookRepository;
using BookMeService.IBookService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookMeService
{
    public class GridService : IGridService
    {
        private readonly IGridRepository _gridreposiroty;
        private readonly ImasterData _masterdata;
      
        public GridService(IGridRepository gridreposiroty, ImasterData masterdata)
        {
            _gridreposiroty = gridreposiroty;
            _masterdata = masterdata;

        }

        public async Task<GridItem[]> GetGridItem()
        {
            try
            {
                
                var result = await _gridreposiroty.GetGridItem();
                //var items = _masterdata.GetMasterData();
                var data = (from pX in result
                            select new GridItem
                            {
                                Id = pX.id,
                                ImageUrl = pX.imageUrl,
                                BoardBasis = pX.boardBasis,
                                location = pX.location,
                                DateofTravel = pX.datesOfTravel[0] + "," + pX.datesOfTravel[1],
                                /*,*/
                                Name = pX.name,
                                rating = pX.rating,
                                rooms = MaptoRoomDetails(pX)


                            }).ToArray();
                return data;
            }
            catch (Exception ex)
            {
                
                throw ;
            }

        }


        public async Task<GridItem> GetItemByIdAsync(int id)
        {
            var items = _masterdata.GetMasterData();
            return items.FirstOrDefault(x => x.Id == id);
        }

        private roomdetails[] MaptoRoomDetails(GridItemDataTableMapper tablemaper)
        {
            if (tablemaper == null)
                return null;
            return tablemaper.rooms.Select(r => new roomdetails
            {
                amount = r.amount,
                RoomType = r.roomType

            }).ToArray();

        }
    }
}
