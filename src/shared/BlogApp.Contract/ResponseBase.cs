using System.Collections.Generic;

namespace BlogApp.Contract
{
    public class ResponseBase
    {
        public List<ResponseMessage> Messages { get; set; } = new List<ResponseMessage>();
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess => StatusCode >= 200 & StatusCode < 300;
    }
}