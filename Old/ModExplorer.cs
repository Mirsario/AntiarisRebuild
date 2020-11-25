using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris
{
	public static class ModExplorer
	{
		public const int frameTile = 18;
		public static List<Point> chestTiles;
		public static List<Point> chestTiles2;

		internal static void _initialize()
		{
			chestTiles = new List<Point>();
			chestTiles2 = new List<Point>();
		}

		public static void _drawMapIcon(Mod mod, ref string text)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(ModLoader.GetMod("Antiaris"));
			if (aPlayer.foundChest)
			{
				_foundChests(player);
				_drawIcons(mod, Main.spriteBatch);
			}
		}

		private static void _drawIcons(Mod mod, SpriteBatch spriteBatch)
		{
			ReLogic.Content.Asset<Texture2D> chest = mod.GetTexture("Items/Equipables/Accessories/ChestIcon");
			ReLogic.Content.Asset<Texture2D> chest_ = mod.GetTexture("Items/Equipables/Accessories/ChestIcon2");
			var startPosition = new Vector2();
			foreach (Point chest2 in chestTiles)
			{
				startPosition = AntiarisHelper.FoundPosition(new Vector2(chest2.X + 1f, chest2.Y + 1f));
				var newStartPosition = new Rectangle((int)startPosition.X, (int)startPosition.Y, chest.Width, chest.Height);
				spriteBatch.Draw(chest, newStartPosition, null, Color.White, 0f, new Vector2(chest.Width / 2, chest.Height / 2), SpriteEffects.None, 0f);
			}
			foreach (Point chest2_ in chestTiles2)
			{
				startPosition = AntiarisHelper.FoundPosition(new Vector2(chest2_.X + 1f, chest2_.Y + 1f));
				var newStartPosition = new Rectangle((int)startPosition.X, (int)startPosition.Y, chest_.Width, chest_.Height);
				spriteBatch.Draw(chest_, newStartPosition, null, Color.White, 0f, new Vector2(chest_.Width / 2, chest_.Height / 2), SpriteEffects.None, 0f);
			}
		}

		private static void _foundChests(Player player)
		{
			if ((int)Main.time % 60 == 0)
			{
				chestTiles.Clear();
			}
			if ((int)Main.time % 60 == 0)
			{
				chestTiles2.Clear();
			}
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(ModLoader.GetMod("Antiaris"));
			int tileL = ((int)player.Center.X - 800 + 8) / 16;
			int tileR = ((int)player.Center.X + 800 + 8) / 16;
			int tileT = ((int)player.Center.Y - 800 + 8) / 16;
			int tileB = ((int)player.Center.Y + 800 + 8) / 16;
			tileL = Math.Max(tileL, (int)Main.leftWorld / 16);
			tileR = Math.Min(tileR, (int)Main.rightWorld / 16);
			tileT = Math.Max(tileT, (int)Main.topWorld / 16);
			tileB = Math.Min(tileB, (int)Main.bottomWorld / 16);
			for (int y = tileT + 1; y < tileB; y += 2)
			{
				for (int x = tileL + 1; x < tileR; x += 2)
				{
					Tile tile = Main.tile[x, y];
					if (tile == null)
					{
						continue;
					}
					if (aPlayer.foundChest)
					{
						_addChest(y, x, tile);
						_addChest2(y, x, tile);
					}
				}
			}
		}

		private static void _addChest(int y, int x, Tile tile)
		{
			for (int h = 0; h < 2; h++)
			{
				for (int w = 0; w < 2; w++)
				{
					if (tile.type == 21 && tile.frameX == w * frameTile &&
						tile.frameY == 0 + h * frameTile)
					{
						chestTiles.Add(new Point(x - w, y - h));
					}
				}
			}
		}

		private static void _addChest2(int y, int x, Tile tile)
		{
			for (int h = 0; h < 2; h++)
			{
				for (int w = 0; w < 2; w++)
				{
					if (tile.type == 21 && tile.frameX == 36 + w * frameTile &&
						tile.frameY == 0 + h * frameTile)
					{
						chestTiles2.Add(new Point(x - w, y - h));
					}
				}
			}
		}
	}
}
