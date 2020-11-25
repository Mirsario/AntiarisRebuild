using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Commands
{
	public class GenerateCoveCommand : ModCommand
	{
		public override string Command => "generateCove";

		public override string Usage => "/generateCove";

		public override CommandType Type => CommandType.Chat;

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Mod mod = ModLoader.GetMod("Antiaris");
			string PirateCoveCommand1 = Language.GetTextValue("Mods.Antiaris.PirateCoveCommand1");
			string PirateCoveCommand3 = Language.GetTextValue("Mods.Antiaris.PirateCoveCommand3");
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText(PirateCoveCommand1, 255, 0, 21);
				ModContent.GetInstance<AntiarisWorld>().AddPirateCove();
			}
			else
			{
				Main.NewText(PirateCoveCommand3, 255, 0, 21);
			}
		}
	}
}