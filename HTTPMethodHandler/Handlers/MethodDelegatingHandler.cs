using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HTTPMethodHandler.Handlers
{
    public class MethodDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken
            )
        {
            // STEP 1: Global message-level logic that must be executed BEFORE the request
            //          is sent on to the action method
            string[] _methods = { "PUT", "PATCH", "DELETE", "HEAD", "VIEW" };
            var _header = "X-HTTP-Method-Override";

            if (
                request.Method == HttpMethod.Post && 
                request.Headers.Contains(_header)
                )
            {
                var method = request.Headers.GetValues(_header).FirstOrDefault();
                if (_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    request.Method = new HttpMethod(method.ToUpperInvariant());
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                }
            }

            // STEP 2: Call the rest of the pipeline, all the way to a response message
            var response = await base.SendAsync(request, cancellationToken);

            // STEP 3: Any global message-level logic that must be executed AFTER the request
            //          has executed, before the final HTTP response message

            // STEP 4:  Return the final HTTP response
            return response;
        }
    }
}