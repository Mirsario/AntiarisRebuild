﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Antiaris
{
	public static class MapIcons
	{
		public static void Icon(Mod mod, ref string text, int type, float x, float y)
		{
			Player player = Main.LocalPlayer;
			MapIcons.DrawIcon(mod, Main.spriteBatch, player, type, x, y);
		}

		public static void DrawIcon(Mod mod, SpriteBatch spriteBatch, Player player, int type, float x, float y)
		{
			string PirateCove = Language.GetTextValue("Mods.Antiaris.PirateCove");
			string Quest = Language.GetTextValue("Mods.Antiaris.Quest");
			Texture2D texture = mod.GetTexture("Miscellaneous/PirateMark");
			string value = PirateCove;
			//0 - cove, 1 - quest, 2 - questReady, 3 - prey
			if (type == 1)
			{
				texture = mod.GetTexture("Miscellaneous/QuestIcon2");
				value = "";
			}
			if (type == 2)
			{
				texture = mod.GetTexture("Miscellaneous/QuestIcon3");
				value = "";
			}
			if (type == 3)
			{
				texture = mod.GetTexture("Miscellaneous/Prey");
				value = "";
			}
			int lineAmount;
			string[] strArray = Utils.WordwrapString(value, Main.fontMouseText, 460, 10, out lineAmount);
			lineAmount++;
			Vector2 startpositionN = MapIcons.CheckpositionN(new Vector2((float)(x + 1), (float)(y + ((type == 2) ? -7 : 1))));
			if (startpositionN.X > Main.screenWidth - (double)(22 * lineAmount))
			{
				startpositionN.X = Main.screenWidth - 22 * lineAmount;
			}
			if (startpositionN.X < (double)(22 * lineAmount))
			{
				startpositionN.X = 22 * lineAmount;
			}
			if (startpositionN.Y > Main.screenHeight - (double)(30 * lineAmount))
			{
				startpositionN.Y = Main.screenHeight - 30 * lineAmount;
			}
			if (startpositionN.Y < 30.0 * lineAmount)
			{
				startpositionN.Y = 30 * lineAmount;
			}
			spriteBatch.Draw(texture, startpositionN, null, Color.White, 0.0f, Utils.Size(texture) / 2f, 1f, SpriteEffects.None, 0f);
			if (Utils.CenteredRectangle(startpositionN, Utils.Size(texture)).Contains(new Point(Main.mouseX, Main.mouseY)) && !PlayerInput.IgnoreMouseInterface)
			{
				float x2 = 0f;
				for (int i = 0; i < lineAmount; i++)
				{
					float j = Main.fontMouseText.MeasureString(strArray[i]).X;
					if (x2 < (double)j)
					{
						x2 = j;
					}
				}
				if (x2 > 460.0)
				{
					x2 = 460f;
				}
				Vector2 vector2 = new Vector2(Main.mouseX, Main.mouseY) + new Vector2(16f);
				if (vector2.Y > (double)(Main.screenHeight - 30 * lineAmount))
				{
					vector2.Y = Main.screenHeight - 30 * lineAmount;
				}
				if (vector2.X > Main.screenWidth - (double)x2)
				{
					vector2.X = Main.screenWidth - x2;
				}
				if (!string.IsNullOrEmpty(value))
				{
					Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, value, vector2.X, vector2.Y, new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), Color.Black, default(Vector2), 1f);
				}
				Main.mouseText = true;
			}
		}


		public static Vector2 CheckpositionN(Vector2 pos)
		{
			Vector2 screen = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
			Vector2 fullScreen = pos - Main.mapFullscreenPos;
			fullScreen *= Main.mapFullscreenScale / 16f;
			fullScreen = fullScreen * 16f + screen;
			Vector2 positionN = new Vector2((int)fullScreen.X, (int)fullScreen.Y);
			return positionN;
		}
	}
}
