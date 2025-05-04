using BlazorBuilds.Components.DialogFramework;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorBuilds.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped<ModalDialogService>();

            await builder.Build().RunAsync();
        }
    }
}
