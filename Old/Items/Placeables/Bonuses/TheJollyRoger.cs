using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Bonuses
{
	public class TheJollyRoger : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 48;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.createTile = ModContent.TileType<TheJollyRoger>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Jolly Roger");
			Tooltip.SetDefault("Nearby enemies drop more coins");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "海盗旗");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在其附近的敌人会掉落更多的钱币");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Весёлый Роджер");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "С ближайших врагов выпадает больше монет");
		}
	}
}