using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class BrothersPenguins : ModItem
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
			item.createTile = ModContent.TileType<BrothersPenguins>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brothers Penguins");
			Tooltip.SetDefault("M. Pet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Братья-пингвины");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "М. Пет");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "企鹅兄弟");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "M.Pet");
		}
	}
}