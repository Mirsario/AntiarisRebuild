﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Bonuses
{
	public class BlazingBrazier : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Blazing Brazier");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Пылающая жаровня");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "不灭篝火");
			AddMapEntry(new Color(70, 70, 70), name);
			dustType = 53;
			animationFrameHeight = 54;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(TileTags.Hot);
		}*/

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			if (frameX == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<BlazingBrazier>());
			}
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if (frameCounter > 4)
			{
				frameCounter = 0;
				frame++;
				if (frame > 5)
				{
					frame = 0;
				}
			}
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
			Player player = Main.LocalPlayer;
			if (closer && !player.dead)
			{
				player.AddBuff(ModContent.BuffType<BlazingFeet>(), 60, true);
			}
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1.5f;
			g = 0.7f;
			b = 0.7f;
		}
	}
}

