using PokemonReviewApp.Infrastructure.Models;

namespace PokemonReviewApp.Infrastructure.Configuration
{
    public class ExternalMicroServicesConfig
    {
        public string JsonPlaceholder { get; set; } = string.Empty;
        public ImdbApiSettings ImdbApi { get; set; } = new ImdbApiSettings();
    }
}
