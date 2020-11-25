using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Bonuses
{
	public class DazzlingMirror : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dazzling Mirror");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Сияющее зеркало");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "璀璨之镜");
			AddMapEntry(new Color(70, 70, 70), name);
			dustType = 53;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if (frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<DazzlingMirror>());
			}
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
			Main.spriteBatch.Draw(mod.GetTexture("Glow/DazzlingMirror_GlowMask"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + Zero, new Rectangle(tile.frameX, tile.frameY, 16, Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if (closer && !player.dead)
			{
				player.AddBuff(ModContent.BuffType<MirrorBlessing>(), 60, true);
			}
		}
	}
}

