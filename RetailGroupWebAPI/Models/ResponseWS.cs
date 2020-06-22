using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailGroupWebAPI.Models
{
    public class ResponseWS
    {
        public int Id { get; set; }
        public int ErrorCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorText { get; set; }

        public ResponseWS(int id, int errCode, string errText = null){
            Id = id;
            ErrorCode = errCode;
            ErrorText = errText;
        }
    }

    public enum ErrorCode
    {
        OK = 0,
        DBError,
        MethodNotFound,
        SmthWrong
    }
}
