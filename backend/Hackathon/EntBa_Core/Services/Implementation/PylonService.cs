using EntBa_Core.Enums;
using EntBa_Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace EntBa_Core.Services.Implementation
{
    public class PylonService : IPylonService
    {
        private readonly ILogger<PylonService> _logger;

        private PylonStateEnum _pylonState;

        public PylonService(ILogger<PylonService> logger)
        {
            _logger = logger;
        }

        public async Task Open()
        {
            // out of scope
            _logger.LogInformation("Opening pylon.");
            _pylonState = PylonStateEnum.Opened;
        }

        public async Task Close()
        {
            // out of scope
            _logger.LogInformation("Closing pylon.");
            _pylonState = PylonStateEnum.Closed;
        }

        public async Task<PylonStateEnum> GetState()
        {
            // out of scope
            _logger.LogInformation("Pylon state: {pylonState}", _pylonState);
            return _pylonState;
        }
    }
}
