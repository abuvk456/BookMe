using BookMeModel;
using BookMeService.IBookService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookMeService.MasterService;

namespace BookMeService
{
    public  class MasterService: ImasterData
    {
        private readonly string _filepath;
        private readonly List<GridItem> _masterData;

        public MasterService(IConfiguration configuration)
        {
            
            _filepath = configuration["GridDataFilePath"];
            _masterData = GetAllDataFromJsonFiles().Result;
        }

        public IEnumerable<GridItem> GetMasterData()
        {
                return _masterData;
        }


        private async Task<List<GridItem>> GetAllDataFromJsonFiles()
        {
            var jsonData = await File.ReadAllTextAsync(_filepath);
            return JsonConvert.DeserializeObject<List<GridItem>>(jsonData);
        }
    }

}

