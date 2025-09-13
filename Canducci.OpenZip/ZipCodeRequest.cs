using System;
using System.Threading.Tasks;

namespace Canducci.OpenZip
{
    public class ZipCodeRequest : IZipCodeRequest
    {
        private readonly IWebRequestClient _webRequestClient;

        public ZipCodeRequest(IWebRequestClient webRequestClient)
        {
            _webRequestClient = webRequestClient;
        }

        public async Task<ZipCodeResult> GetZipCodeAsync(ZipCodeValue zipCode)
        {
            return await GetZipCodeAsync(zipCode?.Number);
        }

        public async Task<ZipCodeResult> GetZipCodeAsync(string zipCode)
        {
            try
            {
                if (string.IsNullOrEmpty(zipCode))
                {
                    throw new ArgumentNullException(nameof(zipCode), "ZipCode is not null");
                }
                if (zipCode?.Length < 8)
                {
                    throw new ArgumentOutOfRangeException(nameof(zipCode), "ZipCode must be at least 8 characters long.");
                }
                return await _webRequestClient.GetZipCodeAsync(zipCode);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
