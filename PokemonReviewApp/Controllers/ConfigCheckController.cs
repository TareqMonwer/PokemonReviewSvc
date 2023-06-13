using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PokemonReviewApp.Infrastructure.Configuration;
using PokemonReviewApp.Infrastructure.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigCheckController : ControllerBase
    {
        private readonly ExternalMicroServicesConfig _externalMicroServicesConfig;
        public ConfigCheckController(IOptionsSnapshot<ExternalMicroServicesConfig> externalMicroServiceConfig) { 
            _externalMicroServicesConfig = externalMicroServiceConfig.Value;
        }

        [HttpGet("ImdbApiSettings")]
        public ImdbApiSettings Get()
        {
            return _externalMicroServicesConfig.ImdbApi;
        }
    }
}
