using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Placeables.Banners
{
	public class BoarBanner : ModItem
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
			item.useStyle = ItemUseStyleID.Swing;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = ModContent.TileType<Tiles.Banners>();
			item.placeStyle = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boar Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Boar");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大山猪旗");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "附近的玩家针对以下情况获得奖励：大山猪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знамя кабана");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Игроки поблизости получают бонус против: Кабан");
		}
	}
}
