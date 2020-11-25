using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.MusicBoxes
{
	public class TowerKeeperMusicBox2 : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<TowerKeeperMusicBox2>();
			item.width = 28;
			item.height = 32;
			item.rare = ItemRarityID.LightRed;
			item.value = 100000;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Tower Keeper)");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "音乐盒（守塔魔像）");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Музыкальная шкатулка (Хранитель башни)");
		}
	}
}
