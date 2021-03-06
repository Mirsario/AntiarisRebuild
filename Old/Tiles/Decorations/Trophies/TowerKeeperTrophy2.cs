using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations.Trophies
{
	public class TowerKeeperTrophy2 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			dustType = 7;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Trophy");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Трофей");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "荣誉之证");
			AddMapEntry(new Color(120, 85, 60), name);
		}

		/*public void OverhaulInit()
		{
			this.SetTag(TileTags.Flammable);
		}*/

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if (frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<TowerKeeperTrophy2>(), 1, false, 0, false, false);
			}
		}
	}
}