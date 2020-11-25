using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.MusicBoxes
{
	class TowerKeeperMusicBox1 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Music Box");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Музыкальная шкатулка");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "音乐盒");
			AddMapEntry(new Color(191, 142, 111), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 48, ModContent.ItemType<TowerKeeperMusicBox1>(), 1, false, 0, false, false);
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			var Zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				Zero = Vector2.Zero;
			}
			int Height = 16;
			Main.spriteBatch.Draw(mod.GetTexture("Glow/TowerKeeperMusicBox1_GlowMask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = ModContent.ItemType<TowerKeeperMusicBox1>();
		}
	}
}
