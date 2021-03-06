using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class TrueLuck : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Luck");
			Description.SetDefault("Critical strike chance and critical damage is increased by 25%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "幸运觉醒");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 25% 的致命一击率与致命一击伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Истинная удача");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Шанс и показатель критического урона увеличены на 25%");
			Main.pvpBuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).tLuck = true;
			player.rangedCrit += 25;
		}
	}
}
