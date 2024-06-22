using SMW_test.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW_test.Services.Interface
{
    public interface INumberService
    {
        Task AddNumberAsync(int number);
        Task<int?> GetMaxAsync();
        Task<int?> GetMinAsync();
        void SetActiveDataStructure(string dataStructure);
    }

}
