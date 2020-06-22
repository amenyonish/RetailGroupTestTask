using ClientApp.Model;
using ClientApp.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ClientApp.API
{
    public class RetailGroupWebService
    {
        private string url = "https://localhost:44319";
        public async Task<object> SendInfo(ComputerInfo info)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest("computer", DataFormat.Json);
                var cancellationTokenSource = new CancellationTokenSource();
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");
                request.Method = Method.POST;
                request.AddJsonBody(info);

                var restResponse = await client.ExecuteAsync(request, cancellationTokenSource.Token);
                
                if (restResponse.IsSuccessful)
                {
                    try
                    {                       
                        var desResp = JsonConvert.DeserializeObject<RetailGroupResponse>(restResponse.Content);
                        return desResp;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    
                }
                else
                {
                    return new RetailGroupResponse
                    {
                        Id = info.Id,
                        ErrorCode = (int)restResponse.ResponseStatus,
                        ErrorText = restResponse.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {               
                throw ex;
            }
        }
    }
}
