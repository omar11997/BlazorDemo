using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WASM.App;
using WASM.App.Services;

namespace WASM.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //create the application with the default paramters 
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //indicate the roote component of the app
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            // <summary>
            /// Using HttpClient
            /// </summary>
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7201/api/Employee")});

            // <summary>
            /// Using HttpClientFactory
            /// </summary>
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:7201"));
            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri("https://localhost:7201"));

            await builder.Build().RunAsync();
        }
    }
}
