using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Content.Tiles.Furniture
{
	public class Cabinet : MouseItemFurniture
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true;
			Main.tileContainer[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			//Main.tileValue[Type] = 500;
			Main.tileTable[Type] = true;
			Main.tileSolidTop[Type] = true;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[] { 127 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Cabinet");
			name.AddTranslation((int)GameCulture.CultureName.Russian, "Шкаф");
			name.AddTranslation((int)GameCulture.CultureName.Chinese, "柜橱");
			AddMapEntry(new Color(191, 142, 111), name);
			//disableSmartCursor = true;
			adjTiles = new int[] { TileID.Containers };
			//chest = "Cabinet";
			chestDrop = Mod.Find<ModItem>(nameof(Items.Placeables.Furniture.Cabinet)).Type;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, chestDrop, 1, false, 0, false, false);
			Chest.DestroyChest(i, j);
		}
	}
}
