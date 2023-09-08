using Newtonsoft.Json;

namespace EntBa_Core.ModelsLogic
{
    public class CameraResult
    {
        [JsonProperty("processing_time")]
        public int ProcessingTime { get; set; }

        [JsonProperty("plates")]
        public Plate[] Plates { get; set; } = Array.Empty<Plate>();

    }

    public class Plate
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("country_name")]
        public string CountryName { get; set; } = string.Empty;

        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;

        [JsonProperty("confidence")]
        public int Confidence { get; set; }
    }
}
