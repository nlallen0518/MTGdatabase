// ScryfallApiService.cs
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicCardDatabase
{
    public class ScryfallApiService
    {
        public async Task<List<MagicCard>> SearchCards(string query)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.scryfall.com/cards/search?q={query}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(json);
                var cards = new List<MagicCard>();

                foreach (var cardData in data.data)
                {
                    cards.Add(new MagicCard
                    {
                        Name = cardData.name,
                        SetName = cardData.set_name,
                        TypeLine = cardData.type_line,
                        OracleText = cardData.oracle_text,
                        ImageUrl = cardData.image_uris.normal
                        // ... other properties as needed ...
                    });
                }

                return cards;
            }
        }

    }
}
