using BookMeRepository.DataTableMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeRepository.IBookRepository
{
    public interface IGridRepository
    {

        Task<IEnumerable<GridItemDataTableMapper>> GetGridItem();


    }
}
