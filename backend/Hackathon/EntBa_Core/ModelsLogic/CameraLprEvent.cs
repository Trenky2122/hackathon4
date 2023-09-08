using System.Diagnostics.CodeAnalysis;
using HttpMultipartParser;

namespace EntBa_Core.ModelsLogic
{
    public class CameraLprEvent
    {
        public required string LicensePlate { get; set; }
        public required string LicensePlateCountryCode { get; set; }

        [SetsRequiredMembers]
        public CameraLprEvent(IMultipartFormDataParser parser)
        {
            LicensePlate = parser.GetParameterValue("text");
            LicensePlateCountryCode = parser.GetParameterValue("country");
        }
    }
}
