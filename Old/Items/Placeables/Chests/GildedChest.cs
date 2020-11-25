using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Chests
{
	public class GildedChest : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<DeadManChest>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gilded Chest");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "镀金箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Позолоченный сундук");
		}
	}
}
