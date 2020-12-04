using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Antiaris.Content.WorldBuilding.Structures
{
	public abstract class StructureBase
	{
		protected int StartPositionX;
		protected int StartPositionY;

		protected Mod Mod
		{
			get;
		} = ModContent.GetInstance<AntiarisMod>();

		public abstract void Generate(GenerationProgress progress, GameConfiguration configuration);

		protected void PlaceGrids(int fallbackTheme = TileID.Dirt)
		{
			ushort[] theme = GetTileTheme(fallbackTheme);
			ushort[] wallTheme = GetWallTheme(fallbackTheme);
			for (int t = 5; t >= 0; t--)
			{
				ushort type = Framing.GetTileSafely(StartPositionX, StartPositionY + t).type;
				ushort[] newTheme = GetTileTheme(type);
				if (newTheme != null)
				{
					theme = newTheme;
					wallTheme = GetWallTheme(type);
					break;
				}
			}

			StartPositionY += 3;

			for (int X = 0; X < TileGrid.GetLength(1); X++)
			{
				for (int Y = 0; Y < TileGrid.GetLength(0); Y++)
				{
					int i = StartPositionX + X;
					int j = StartPositionY + Y;
					var tile = Framing.GetTileSafely(i, j);

					if (TileGrid[Y, X] != 0)
					{
						WorldGen.PlaceTile(i,
							j,
							// Need to offset type by 1 since 0 is automatically handled
							theme[TileGrid[Y, X] - 1],
							true,
							true,
							-1,
							0);
					}

					if (WallGrid[Y, X] != 0)
					{
						tile.wall = wallTheme[WallGrid[Y, X] - 1];
					}

					byte slope = SlopeGrid[Y, X];
					if (slope == 5)
					{
						tile.halfBrick(true);
					}
					else
					{
						//tile.halfBrick(false);
						tile.slope(slope);
					}
				}
			}
		}

		protected abstract ushort[] GetTileTheme(int type);

		protected abstract ushort[] GetWallTheme(int type);

		protected abstract byte[,] TileGrid
		{
			get;
		}

		protected abstract byte[,] WallGrid
		{
			get;
		}

		//0=none, 1=bottom-left, 2=bottom-right, 3=top-left, 4=top-right, 5=half
		protected abstract byte[,] SlopeGrid
		{
			get;
		}
	}
}
