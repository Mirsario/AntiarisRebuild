﻿using Antiaris.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Content.Tiles.Furniture
{
	public class LeafDray : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Leaf Dray");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Повозка с листьями");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "装有叶子的车");
			AddMapEntry(new Color(220, 181, 151), name);
		}

		/*public void OverhaulInit()
		{
			this.SetTag(TileTags.Flammable);
		}*/

		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, Mod.Find<ModItem>(nameof(Leaf)).Type, Main.rand.Next(15, 20), false, 0, false, false);
				Item.NewItem(i * 16, j * 16, 48, 48, ItemID.Wood, Main.rand.Next(20, 30), false, 0, false, false);
			}
		}
	}
}
