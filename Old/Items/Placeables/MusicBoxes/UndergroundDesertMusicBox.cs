using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.MusicBoxes
{
	public class UndergroundDesertMusicBox : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<UndergroundDesertMusicBox>();
			item.width = 30;
			item.height = 30;
			item.rare = ItemRarityID.LightRed;
			item.value = 100000;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Underground Desert)");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "音乐盒（地下沙漠）");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Музыкальная шкатулка (Подземная пустыня)");
		}
	}
}
