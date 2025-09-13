using System.Threading.Tasks;
namespace Canducci.OpenZip
{
    public interface IZipCodeRequest
    {
        Task<ZipCodeResult> GetZipCodeAsync(string zipCode);
    }
}