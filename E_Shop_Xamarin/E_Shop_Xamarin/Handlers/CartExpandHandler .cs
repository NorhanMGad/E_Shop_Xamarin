using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E_Shop_Xamarin.Handlers
{
    public class CartExpandHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage>
        SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool requestToTodoTable = request.RequestUri.PathAndQuery
                .StartsWith("/tables/cart", StringComparison.OrdinalIgnoreCase)
                    && request.Method == HttpMethod.Get;
            if (requestToTodoTable)
            {
                UriBuilder builder = new UriBuilder(request.RequestUri);
                string query = builder.Query;
                if (!query.Contains("$expand"))
                {
                    if (string.IsNullOrEmpty(query))
                    {
                        query = string.Empty;
                    }
                    else
                    {
                        query = query + "&";
                    }

                    query = query + "$expand=RelatedItem";
                    builder.Query = query.TrimStart('?');
                    request.RequestUri = builder.Uri;
                }
            }

            var result = await base.SendAsync(request, cancellationToken);
            return result;
        }
    }
}

