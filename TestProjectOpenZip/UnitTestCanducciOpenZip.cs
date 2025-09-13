using Canducci.OpenZip;
namespace TestProjectOpenZip
{
    public class Tests
    {
        internal IWebRequestClient WebRequestClient;
        internal ZipCodeRequest ZipCodeRequest;

        [SetUp]
        public void Setup()
        {
            WebRequestClient = new WebRequestClient(new HttpClient()
            {
                BaseAddress = new Uri("https://opencep.com/v1/")
            });
            ZipCodeRequest = new(WebRequestClient);
        }

        [Test]
        public async Task TestCanducciOpenZipOk()
        {
            string zipCode = "19206-082";           
            ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCode);
            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsTrue(result.Data.ZipCode == zipCode);
        }

        [Test]
        public async Task TestCanducciOpenZipOkWithZipCodeParseValue()
        {
            string zipCode = "19206-082";
            ZipCodeValue zipCodeValue = ZipCodeValue.Parse(zipCode);
            ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCodeValue);
            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsTrue(result.Data.ZipCode == zipCode);
        }

        [Test]
        public async Task TestCanducciOpenZipOkWithZipCodeTryParseValue()
        {
            string zipCode = "19206-082";
            bool status = ZipCodeValue.TryParse(zipCode, out ZipCodeValue zipCodeValue);
            Assert.IsTrue(status);
            ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCodeValue);
            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsTrue(result.Data.ZipCode == zipCode);
        }


        [Test]
        public async Task TestCanducciOpenZipOkWithZipCodeTryParseImplicitValue()
        {
            ZipCodeValue zipCodeValue = "19206-082";
            ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCodeValue);
            Assert.IsTrue(result.IsValid);
            Assert.IsTrue(result.StatusCode == 200);
            Assert.IsTrue(result.Data.ZipCode.Replace("-","") == zipCodeValue.Number);
        }


        [Test]
        public async Task TestCanducciOpenZipFail()
        {
            string zipCode = "11111-111";
            ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCode);
            Assert.IsFalse(result.IsValid);            
        }
    }
}