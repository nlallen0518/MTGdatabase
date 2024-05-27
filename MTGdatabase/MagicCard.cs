using System.Collections.Generic;

namespace MagicCardDatabase
{
    public class MagicCard
    {
        public string Id { get; set; } // Scryfall unique identifier
        public string Name { get; set; }
        public string SetName { get; set; } // set_name in Scryfall
        public string Set { get; set; } // set (abbreviated code) in Scryfall
        public string CollectorNumber { get; set; }
        public string TypeLine { get; set; } // type_line in Scryfall
        public string OracleText { get; set; }
        public string ManaCost { get; set; } // mana_cost in Scryfall
        public List<string> Colors { get; set; } // colors in Scryfall
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Rarity { get; set; }
        public string ImageUrl { get; set; } // Small image URI for search results
        public string ImageUrisNormal { get; set; } // Normal image URI for detailed view
        public double? PriceUsd { get; set; } // USD price from Scryfall (can be null)
        public double? PriceEur { get; set; } // EUR price from Scryfall (can be null)
        public double? PriceTix { get; set; } // MTGO Tix price from Scryfall (can be null)
        public bool Foil { get; set; } // Foil version available (not directly from Scryfall, might need calculation)

        // Additional properties (optional, if you want to display them):
        public string FlavorText { get; set; }
        public string Artist { get; set; }
        public string LegalityStandard { get; set; }
        public string LegalityModern { get; set; }
        public string LegalityPioneer { get; set; }
        // ... etc. 
    }
}
