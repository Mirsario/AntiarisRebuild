using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Bonuses
{
	public class TreeofLife : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Tree of Life");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Дерево жизни");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "生命树");
			AddMapEntry(new Color(40, 101, 13), name);
			dustType = 7;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(TileTags.Flammable);
		}*/

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if (frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<TreeofLife>());
			}
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if (closer && !player.dead)
			{
				player.AddBuff(ModContent.BuffType<InnerZen>(), 60, true);
			}
		}
	}
}


