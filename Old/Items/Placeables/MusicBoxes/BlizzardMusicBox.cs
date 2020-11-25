using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Placeables.MusicBoxes
{
	public class BlizzardMusicBox : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<BlizzardMusicBox>();
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.LightRed;
			item.value = 100000;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Blizzard)");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "音乐盒（暴风雪）");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Музыкальная шкатулка (Метель)");
		}
	}
}
