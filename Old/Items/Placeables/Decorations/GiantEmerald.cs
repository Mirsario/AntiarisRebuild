using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class GiantEmerald : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 35, 0, 0);
			item.createTile = ModContent.TileType<GiantEmerald>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Giant Emerald");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "巨大翡翠");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гигантский изумруд");
		}
	}
}