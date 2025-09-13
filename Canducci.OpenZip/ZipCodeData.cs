namespace Canducci.OpenZip
{
    /// <summary>
    /// Represents detailed information about a specific zip code, including its associated address, locality, state,
    /// and other related metadata.
    /// </summary>
    /// <remarks>This class is typically used to store and retrieve information about a zip code and its
    /// corresponding geographical and administrative details. The properties of this class are populated using JSON
    /// serialization, with property names mapped to their respective JSON keys.</remarks>
    public class ZipCodeData
    {
        [System.Text.Json.Serialization.JsonConstructor]
        public ZipCodeData
        (
            string zipCode,
            string address,
            string complement,
            string unity,
            string neighborhood,
            string locality,
            string uf,
            string state,
            string region,
            string ibge
        )
        {
            ZipCode = zipCode;
            Address = address;
            Complement = complement;
            Unity = unity;
            Neighborhood = neighborhood;
            Locality = locality;
            Uf = uf;
            State = state;
            Region = region;
            Ibge = ibge;
        }

        [System.Text.Json.Serialization.JsonPropertyName("cep")]
        public string ZipCode { get; }

        [System.Text.Json.Serialization.JsonPropertyName("logradouro")]
        public string Address { get; }

        [System.Text.Json.Serialization.JsonPropertyName("complemento")]
        public string Complement { get; }

        [System.Text.Json.Serialization.JsonPropertyName("unidade")]
        public string Unity { get; }

        [System.Text.Json.Serialization.JsonPropertyName("bairro")]
        public string Neighborhood { get; }

        [System.Text.Json.Serialization.JsonPropertyName("localidade")]
        public string Locality { get; }

        [System.Text.Json.Serialization.JsonPropertyName("uf")]
        public string Uf { get; }

        [System.Text.Json.Serialization.JsonPropertyName("estado")]
        public string State { get; }

        [System.Text.Json.Serialization.JsonPropertyName("regiao")]
        public string Region { get; }

        [System.Text.Json.Serialization.JsonPropertyName("ibge")]
        public string Ibge { get; }
    }
}
