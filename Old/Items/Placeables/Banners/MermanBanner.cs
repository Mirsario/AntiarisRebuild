using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Banners
{
	public class MermanBanner : ModItem
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
			item.placeStyle = 25;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Merman Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Merman");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знамя русала");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Игроки поблизости получают бонус против: Русал");
		}
	}
}
