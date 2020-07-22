using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Model
{
    public class Destination
    {
        public string Uri { get; set; }
        public bool RequiresAuthentication { get; set; }
        static readonly HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> SendRequest(HttpRequest request)
        {
            string requestContent;
            using (Stream receiveStream = request.Body)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    requestContent = await readStream.ReadToEndAsync();
                }
            }

            using (var newRequest = new HttpRequestMessage(new HttpMethod(request.Method), CreateDestinationUri(request)))
            {
                newRequest.Content = new StringContent(requestContent, Encoding.UTF8, request.ContentType);
                return await client.SendAsync(newRequest);
                //using (var response = await client.SendAsync(newRequest))
                //{
                //    return response;
                //}
            }
        }

        private string CreateDestinationUri(HttpRequest request)
        {
            string requestPath = request.Path.ToString();
            string queryString = request.QueryString.ToString();

            string endpoint = "";
            string[] endpointSplit = requestPath.Substring(1).Split('/');

            if (endpointSplit.Length > 1)
                endpoint = endpointSplit[1];


            return Uri + endpoint + queryString;
        }

    }
}
