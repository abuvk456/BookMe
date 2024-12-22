using BookMeRepository.DataTableMapper;
using BookMeRepository.IBookRepository;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookMeRepository
{
    public class GridRepository : IGridRepository
    {

        private readonly string _filepath;
        
        public GridRepository(IConfiguration configuration)
        {

            _filepath = configuration["GridDataFilePath"];

        }


        public async Task<IEnumerable<GridItemDataTableMapper>> GetGridItem()
        {
            try
            {
                if (!File.Exists(_filepath))
                {
                    throw new FileNotFoundException($"Grid data file not found at {_filepath}");

                }

                var json = await File.ReadAllTextAsync(_filepath);

                return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<GridItemDataTableMapper>>(json);

            }
            catch(Exception ex)
            {
                throw ex;


            }

           
        }
    }
}
