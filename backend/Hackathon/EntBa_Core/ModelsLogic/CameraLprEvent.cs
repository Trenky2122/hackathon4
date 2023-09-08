using Newtonsoft.Json;

namespace EntBa_Core.ModelsLogic
{
    public class CameraLprEvent
    {
        public required string LicensePlate { get; set; }
        public required string LicensePlateCountryCode { get; set; }
    }
}
