using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class GildedCup : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 18;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.createTile = ModContent.TileType<GildedCup>();
			item.holdStyle = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Cup");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "镀金杯");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Позолоченная чаша");
		}
	}
}