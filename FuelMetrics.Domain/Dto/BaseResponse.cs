using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelMetrics.Domain.Dto
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public string ResponseMessage { get; set; }
        public string Error { get; set; }
        public BaseResponse(T data, string error = null, string responseMessage = null)
        {
            this.Data = data;
            this.ResponseMessage = string.IsNullOrEmpty(responseMessage) ? Constant.Success : responseMessage;
            this.Error = error;
        }
        public BaseResponse(string error, string responseMessage = null)
        {
            this.ResponseMessage = string.IsNullOrEmpty(responseMessage) ? Constant.Failed : responseMessage;
            this.Error = error;
        }

        public BaseResponse()
        {
            var responseMessage = "An error occured, please contact administrator for help";
            this.ResponseMessage = string.IsNullOrEmpty(responseMessage) ? Constant.Failed : responseMessage;
            this.Error = null;
        }

    }
}
