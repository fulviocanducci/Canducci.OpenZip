using System.Threading.Tasks;
namespace Canducci.OpenZip
{
    public interface IWebRequestClient
    {
        Task<ZipCodeResult> GetZipCodeAsync(string zipCode);
    }
}