using Microsoft.Extensions.DependencyInjection;
using System;
namespace Canducci.OpenZip
{
    public static class Extensions
    {
        public static IServiceCollection AddOpenZip(this IServiceCollection services)
        {
            services.AddHttpClient<IWebRequestClient, WebRequestClient>(client =>
            {
                client.BaseAddress = new Uri("https://opencep.com/v1/");
            });
            services.AddTransient<IZipCodeRequest, ZipCodeRequest>();
            return services;
        }
    }

    internal static class ExtensionsInternal
    {
        internal static string ToNumber(this string zipCode)
        {
            return System.Text.RegularExpressions.Regex.Replace(zipCode, "[^0-9]", "");
        }
    }
}
