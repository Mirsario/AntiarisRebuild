using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Banners
{
	public class BluePixieBanner : ModItem
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
			item.placeStyle = 15;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Pixie Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Blue Pixie");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знамя голубой пикси");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Игроки поблизости получают бонус против: Голубая пикси");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓝色小精灵旗");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "附近的玩家针对以下情况获得奖励：蓝色小精灵");
		}
	}
}
