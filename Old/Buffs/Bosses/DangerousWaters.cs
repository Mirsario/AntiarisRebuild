using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Bosses
{
	public class DangerousWaters : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dangerous Waters");
			Description.SetDefault("Waters are going to consume you even faster");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Опсаные воды");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Воды поглотят вас ещё быстрее");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).dangerousWaters = true;
		}
	}
}
