using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class TheKiller : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(0, 0, 2, 0);
			item.createTile = ModContent.TileType<TheKiller>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Killer");
			Tooltip.SetDefault("H. Ara");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Убийца");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Х. Ара");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "The Killer");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "H. Ara");
		}
	}
}