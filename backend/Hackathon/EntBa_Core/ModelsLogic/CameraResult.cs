using Newtonsoft.Json;

namespace EntBa_Core.ModelsLogic
{
    public class CameraResult
    {
        [JsonProperty("processing_time")]
        public int ProcessingTime { get; set; }

        [JsonProperty("plates")]
        public required Plate[] Plates { get; set; }

    }

    public class Plate
    {
        [JsonProperty("text")]
        public required string Text { get; set; }

        [JsonProperty("country")]
        public required string Country { get; set; }

        [JsonProperty("country_name")]
        public required string CountryName { get; set; }

        [JsonProperty("state")]
        public required string State { get; set; }

        [JsonProperty("confidence")]
        public int Confidence { get; set; }
    }
}
