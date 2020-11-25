using Terraria;
using Terraria.ModLoader;

namespace Antiaris
{
	public class AntiarisWall : GlobalWall
	{
		public override bool CanExplode(int i, int j, int type)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.mirrorZone && (type == 5 || type == 174 || type == 33))
			{
				return false;
			}

			return base.CanExplode(i, j, type);
		}

		public override void KillWall(int i, int j, int type, ref bool fail)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.mirrorZone && (type == 5 || type == 174 || type == 33))
			{
				fail = true;
			}
		}

		private int wallDrop;

		public override bool Drop(int i, int j, int type, ref int dropType)
		{
			Player player = Main.LocalPlayer;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.mirrorZone && (type == 5 || type == 174 || type == 33))
			{
				dropType = 0;
				return false;
			}
			else
			{
				return base.Drop(i, j, type, ref dropType);
			}
		}
	}
}