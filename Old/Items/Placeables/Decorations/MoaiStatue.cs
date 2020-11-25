using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Decorations
{
	public class MoaiStatue : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 64;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.createTile = ModContent.TileType<MoaiStatue>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moai Statue");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "摩艾石像");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Статуя Моаи");
		}
	}
}
