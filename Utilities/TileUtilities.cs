using System;
using Terraria;

namespace Antiaris.Utilities
{
	public static class TileUtilities
	{
		public static byte GetLiquidLevel(int x, int y, LiquidType liquidType = LiquidType.Any)
		{
			if (!WorldGen.InWorld(x, y))
				return 0;

			Tile tile = Main.tile[x, y];
			if (tile == null)
				return 0;

			if (liquidType == LiquidType.Any)
			{
				return tile.liquid;
			}
			if (liquidType.HasFlag(LiquidType.Water) && !tile.lava() && !tile.honey())
			{
				return tile.liquid;
			}
			if (liquidType.HasFlag(LiquidType.Lava) && tile.lava())
			{
				return tile.liquid;
			}
			if (liquidType.HasFlag(LiquidType.Honey) && tile.honey())
			{
				return tile.liquid;
			}
			return 0;
		}
	}

	[Flags]
	public enum LiquidType
	{
		None = 0,
		Water = 1,
		Lava = 2,
		Honey = 4,
		Any = Water + Lava + Honey
	}
}
