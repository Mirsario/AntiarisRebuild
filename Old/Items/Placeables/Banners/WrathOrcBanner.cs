using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Banners
{
	public class WrathOrcBanner : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<Banners>();
			item.placeStyle = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrath Orc Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Wrath Orc");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "狂兽人旗");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "附近的玩家针对以下情况获得奖励：狂兽人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знамя яростного орка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Игроки поблизости получают бонус против: Яростный орк");
		}
	}
}
