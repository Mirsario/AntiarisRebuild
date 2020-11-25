using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.Trophies
{
	public class TowerKeeperTrophy2 : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.createTile = ModContent.TileType<TowerKeeperTrophy2>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tower Keeper Trophy");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "守塔魔像荣誉之证");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Трофей Хранителя башни");

		}
	}
}
