﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Content.Tiles.Furniture
{
	public class BorealMailbox : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleWrapLimit = 2; //not really necessary but allows me to add more subtypes of chairs below the example chair texture
			TileObjectData.newTile.StyleMultiplier = 2; //same as above
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place example chairs facing the same way as the player
			TileObjectData.addAlternate(1); //facing right will use the second texture style
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Mailbox");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "信箱");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Почтовый ящик");
			AddMapEntry(new Color(220, 181, 151), name);
		}

		/*public void OverhaulInit()
		{
			this.SetTag(TileTags.Flammable);
		}*/

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, Mod.Find<ModItem>(nameof(Items.Placeables.Furniture.BorealMailbox)).Type, 1, false, 0, false, false);
		}
	}
}
