using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    static public class HttpContextAccessor
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public HttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        //}
        static public HttpContext Clone(this HttpContext httpContext, bool copyBody)
        {
            var existingRequestFeature = httpContext.Features.Get<IHttpRequestFeature>();

            var requestHeaders = new Dictionary<string, StringValues>(existingRequestFeature.Headers.Count, StringComparer.OrdinalIgnoreCase);
            foreach (var header in existingRequestFeature.Headers)
            {
                requestHeaders[header.Key] = header.Value;
            }

            var requestFeature = new HttpRequestFeature
            {
                Protocol = existingRequestFeature.Protocol,
                Method = existingRequestFeature.Method,
                Scheme = existingRequestFeature.Scheme,
                Path = existingRequestFeature.Path,
                PathBase = existingRequestFeature.PathBase,
                QueryString = existingRequestFeature.QueryString,
                RawTarget = existingRequestFeature.RawTarget,
                Headers = new HeaderDictionary(requestHeaders),
            };

            if (copyBody)
            {
                // We need to buffer first, otherwise the body won't be copied
                // Won't work if the body stream was accessed already without calling EnableBuffering() first or without leaveOpen
                httpContext.Request.EnableBuffering();
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                requestFeature.Body = existingRequestFeature.Body;
            }

            var features = new FeatureCollection();
            features.Set<IHttpRequestFeature>(requestFeature);
            // Unless we need the response we can ignore it...
            features.Set<IHttpResponseFeature>(new HttpResponseFeature());
            features.Set<IHttpResponseBodyFeature>(new StreamResponseBodyFeature(Stream.Null));

            var newContext = new DefaultHttpContext(features);

            if (copyBody)
            {
                // Rewind for any future use...
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            }

            // Can happen if the body was not copied
            if (httpContext.Request.HasFormContentType && httpContext.Request.Form.Count != newContext.Request.Form.Count)
            {
                newContext.Request.Form = new Microsoft.AspNetCore.Http.FormCollection(httpContext.Request.Form.ToDictionary(f => f.Key, f => f.Value));
            }

            return newContext;
        }
        //public HttpContext CloneHttpContext()
        //{
        //    var originalContext = _httpContextAccessor.HttpContext;

        //    if (originalContext == null)
        //    {
        //        throw new InvalidOperationException("HttpContext is not available in the current context.");
        //    }

        //    var newHttpContext = new DefaultHttpContext
        //    {
        //        // Copy relevant properties
        //        RequestServices = originalContext.RequestServices,
        //        User = originalContext.User,
        //        // Add more properties as needed
        //    };

        //    // Create new request and response objects (since the original ones are read-only)

        //    newHttpContext.Request = CloneHttpRequest(originalContext.Request);
        //    newHttpContext.Response = CloneHttpResponse(originalContext.Response);

        //    return newHttpContext;
        //}

        //private HttpRequest CloneHttpRequest(HttpRequest originalRequest)
        //{
        //    // Create a new request with the necessary properties copied
        //    var newRequest = new DefaultHttpRequest(originalRequest.HttpContext)
        //    {
        //        Method = originalRequest.Method,
        //        // Copy more properties as needed
        //    };

        //    // You might need to clone additional request-related properties

        //    return newRequest;
        //}

        //private HttpResponse CloneHttpResponse(HttpResponse originalResponse)
        //{
        //    // Create a new response with the necessary properties copied
        //    var newResponse = new DefaultHttpResponse(originalResponse.HttpContext)
        //    {
        //        StatusCode = originalResponse.StatusCode,
        //        // Copy more properties as needed
        //    };

        //    // You might need to clone additional response-related properties

        //    return newResponse;
        //}
    }
}
