using GigWorkerExpenseTracking.Application.Services;
using System.Text;

namespace GigWorkerExpenseTracking.API.Services
{
    public class UrlGeneratorService : IUrlGenerator
    {
        private readonly string _baseUrl = "https://localhost:7010/";


        public string GenerateUrl(string path, object routeValues)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "Path cannot be null or empty.");
            }

           //string url = _urlHelper.RouteUrl(path, routeValues);

            // You can further manipulate or customize the generated URL if needed
           // return url;
            // Logic to build the URL using _baseUrl and routeValues
             var urlBuilder = new StringBuilder(_baseUrl);
             urlBuilder.Append("");
             urlBuilder.Append(path);

             if (routeValues != null)
             {
                 urlBuilder.Append("/");

                 var isFirst = true;

                 foreach (var property in routeValues.GetType().GetProperties())
                 {
                     var value = property.GetValue(routeValues);
                     if (value != null)
                     {


                         if(property.Name == "UserId")
                         {
                             urlBuilder.Append($"{Uri.EscapeDataString(value.ToString())}?");
                         }
                         if(property.Name == "rowCount")
                         {
                             urlBuilder.Append($"{property.Name}={Uri.EscapeDataString(value.ToString())}&");
                             isFirst = false;
                         }
                         if (property.Name == "pagNumber")
                         {
                             urlBuilder.Append($"{property.Name}={Uri.EscapeDataString(value.ToString())}");
                             isFirst = false;
                         }


                     }
                 }
             }

             return urlBuilder.ToString();
        }
    }
}