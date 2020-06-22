using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{
    public class RetailGroupResponse 
    {        
        public int Id { get; set; }        
        public int ErrorCode { get; set; }       
        public string ErrorText { get; set; }
    }
}
