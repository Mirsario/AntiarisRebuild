using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Banners
{
	public class PetrousKnight1Banner : ModItem
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
			item.placeStyle = 13;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petrous Knight Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Petrous Knight");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔岩骑士旗");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "附近的玩家针对以下情况获得奖励：魔岩骑士");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знамя окаменевшего рыцаря");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Игроки поблизости получают бонус против: Окаменевший рыцарь");
		}
	}
}
