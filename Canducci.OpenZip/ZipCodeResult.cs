namespace Canducci.OpenZip
{
    /// <summary>
    /// Represents the result of a ZIP code operation, including its status, associated data, and a descriptive reason
    /// phrase.
    /// </summary>
    /// <remarks>This class encapsulates the outcome of a ZIP code operation, providing information about
    /// whether the operation was successful, the HTTP status code, an optional reason phrase, and any associated ZIP
    /// code data. Use the <see cref="Success"/> and <see cref="Fail"/> factory methods to create instances of this
    /// class.</remarks>
    public class ZipCodeResult
    {
        public bool IsValid => StatusCode >= 200 && StatusCode < 300 && Data != null;
        public int StatusCode { get; }
        public string ReasonPhrase { get; }
        public ZipCodeData Data { get; }
        internal ZipCodeResult(int statusCode, ZipCodeData data, string reasonPhrase)
        {
            StatusCode = statusCode;
            Data = data;
            ReasonPhrase = reasonPhrase;
        }
        internal ZipCodeResult(int statusCode, string reasonPhrase)
        {
            StatusCode = statusCode;
            Data = null; 
            ReasonPhrase = reasonPhrase;
        }

        /// <summary>
        /// Creates a successful result for a ZIP code operation.
        /// </summary>
        /// <param name="statusCode">The HTTP status code representing the success of the operation.</param>
        /// <param name="data">The ZIP code data associated with the successful result.</param>
        /// <param name="reasonPhrase">A descriptive phrase providing additional context for the success status.</param>
        /// <returns>A <see cref="ZipCodeResult"/> instance representing the successful operation.</returns>
        public static ZipCodeResult Success(int statusCode, ZipCodeData data, string reasonPhrase) => new ZipCodeResult(statusCode, data, reasonPhrase);

        /// <summary>
        /// Creates a failed <see cref="ZipCodeResult"/> with the specified status code and reason phrase.
        /// </summary>
        /// <param name="statusCode">The HTTP status code representing the failure.</param>
        /// <param name="reasonPhrase">A brief description of the reason for the failure.</param>
        /// <returns>A <see cref="ZipCodeResult"/> instance representing the failure.</returns>
        public static ZipCodeResult Fail(int statusCode, string reasonPhrase) => new ZipCodeResult(statusCode, reasonPhrase);
    }
}
