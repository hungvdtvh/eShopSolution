using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class ApiSucessResult<T>: ApiResult<T>
    {
        public ApiSucessResult(T resultObj)
        {
            IsSucessed = true;
            ResultObj = resultObj;

        }
        public ApiSucessResult()
        {
            IsSucessed = true;
        }
    }
}
