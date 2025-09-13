# Canducci.OpenZip

Canducci.OpenZip is a .NET library that provides functionality for creating, extracting, and managing ZIP files. It is designed to be easy to use and integrates seamlessly with .NET applications.

## Code Example

### namespace

```csharp
using Canducci.OpenZip;
```

### code

```csharp
string zipCode = "19206-082";           
ZipCodeResult result = await ZipCodeRequest.GetZipCodeAsync(zipCode);
if (result.IsValid)
{
	var data = result.Data;
	data.ZipCode
	data.Address
	data.Complement
	data.Unity
	data.Neighborhood
	data.Locality
	data.Uf
	data.State
	data.Region
	data.Ibge
}
```