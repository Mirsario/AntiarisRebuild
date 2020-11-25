using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class Prey : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Prey");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Добыча");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
			Main.persistentBuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.buffTime[buffIndex] = 60;
			npc.GetGlobalNPC<AntiarisNPC>(mod).prey = true;
		}
	}
}
