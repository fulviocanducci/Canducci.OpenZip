using System;
using System.Threading.Tasks;

namespace Canducci.OpenZip
{
    /// <summary>
    /// Represents a request for retrieving information about a zip code.
    /// </summary>
    /// <remarks>This class provides methods to retrieve zip code details asynchronously using a web request
    /// client. It validates the input zip code before making the request and throws appropriate exceptions for invalid
    /// inputs.</remarks>
    public class ZipCodeRequest : IZipCodeRequest
    {
        private readonly IWebRequestClient _webRequestClient;

        public ZipCodeRequest(IWebRequestClient webRequestClient)
        {
            _webRequestClient = webRequestClient;
        }

        /// <summary>
        /// Retrieves information about a ZIP code asynchronously.
        /// </summary>
        /// <param name="zipCode">The ZIP code value to retrieve information for. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a  <see cref="ZipCodeResult"/>
        /// object with details about the specified ZIP code.</returns>
        public async Task<ZipCodeResult> GetZipCodeAsync(ZipCodeValue zipCode)
        {
            return await GetZipCodeAsync(zipCode?.Number);
        }

        /// <summary>
        /// Retrieves information about a specified ZIP code asynchronously.
        /// </summary>
        /// <remarks>This method uses an internal web request client to fetch ZIP code details. Ensure the
        /// provided ZIP code meets the required format to avoid exceptions.</remarks>
        /// <param name="zipCode">The ZIP code to retrieve information for. Must be a non-null, non-empty string with a minimum length of 8
        /// characters.</param>
        /// <returns>A <see cref="ZipCodeResult"/> object containing details about the specified ZIP code.</returns>
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
