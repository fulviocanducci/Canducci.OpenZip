namespace Canducci.OpenZip
{
    public class ZipCodeResult
    {
        public bool IsValid => StatusCode == 200 && Data != null;
        public int StatusCode { get; }
        public string ReasonPhrase { get; }
        public ZipCodeData Data { get; }

        public ZipCodeResult(int statusCode, ZipCodeData data, string reasonPhrase)
        {
            StatusCode = statusCode;
            Data = data;
            ReasonPhrase = reasonPhrase;
        }

        public ZipCodeResult(int statusCode, string reasonPhrase)
        {
            StatusCode = statusCode;
            Data = null; 
            ReasonPhrase = reasonPhrase;
        }

        public static ZipCodeResult Success(int statusCode, ZipCodeData data, string reasonPhrase) => new ZipCodeResult(statusCode, data, reasonPhrase);
        public static ZipCodeResult Fail(int statusCode, string reasonPhrase) => new ZipCodeResult(statusCode, reasonPhrase);
    }
}
