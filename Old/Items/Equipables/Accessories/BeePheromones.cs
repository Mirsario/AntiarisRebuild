using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	public class BeePheromones : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 38;
			item.accessory = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bee Pheromones");
			Tooltip.SetDefault("Bees and hornets become friendly\nHornets become aggressive if attacked");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пчелиные феромоны");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Пчелы и шершни становятся дружелюбными\nШершни становятся агрессивными, если атакованы");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).beePheromones = true;
		}
	}
}
