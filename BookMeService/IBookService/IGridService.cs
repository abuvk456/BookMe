using BookMeModel;
using BookMeRepository.DataTableMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeService.IBookService
{
    public interface IGridService
    {
        Task<GridItem[]> GetGridItem();
        Task<GridItem> GetItemByIdAsync(int id);
       
    }
}
