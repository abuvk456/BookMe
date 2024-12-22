using BookMeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMeService.IBookService
{
   
    public interface ImasterData
    {
        IEnumerable<GridItem> GetMasterData();
        
    }
}
