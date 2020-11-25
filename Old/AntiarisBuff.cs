using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris
{
	public class AntiarisBuff : GlobalBuff
	{
		public override void Update(int type, NPC npc, ref int buffIndex)
		{
			if (type == BuffID.OnFire && npc.type == ModContent.NPCType<HoneySlime>())
			{
				SoundEngine.PlaySound(SoundID.LiquidsHoneyLava, npc.position);
				npc.Transform(ModContent.NPCType<CrispyHoneySlime>());
			}

			if (type == BuffID.OnFire && npc.type == ModContent.NPCType<HoneyGolem>())
			{
				SoundEngine.PlaySound(SoundID.LiquidsHoneyLava, npc.position);
				npc.Transform(ModContent.NPCType<CrispyHoneyGolem>());
			}
		}
	}
}