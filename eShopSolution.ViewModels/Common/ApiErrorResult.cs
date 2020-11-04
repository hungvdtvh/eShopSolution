using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class ApiErrorResult<T>: ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }
        public ApiErrorResult()
        {
            IsSucessed = false;
        }
        public ApiErrorResult(string message)
        {
            IsSucessed = false;
            Message = message;

        }
        public ApiErrorResult(string[] validationErrors)
        {
            IsSucessed = false;
            ValidationErrors = validationErrors;

        }
    }
}
