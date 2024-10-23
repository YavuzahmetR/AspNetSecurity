using Microsoft.Extensions.Options;
using System.Net;

namespace WhiteBlackList.Web.MiddleWares
{
    //App-Level WhiteList Control
    public class IPSafeMiddleWare
    {

        private readonly RequestDelegate _next;
        private readonly IPList _ipList;

        public IPSafeMiddleWare(RequestDelegate _next, IOptions<IPList> _ipList)
        {
            this._next = _next;
            this._ipList = _ipList.Value;
        }


        //Invoke method must be declared. Runs in every HTTP request.
        public async Task Invoke(HttpContext context)
        {
            var requestIpAdress = context.Connection.RemoteIpAddress;

            // Compares Given IpAdresses WhiteList - IP Adress Outer
            var isWhiteList = _ipList.WhiteList.Where(x => IPAddress.Parse(x).Equals(requestIpAdress)).Any();

            if (!isWhiteList) 
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }

            await _next(context);
        }
    }
}
