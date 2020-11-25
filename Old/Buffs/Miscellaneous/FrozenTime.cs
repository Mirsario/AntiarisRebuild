using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class FrozenTime : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frozen Time");
			Description.SetDefault("One second has passed!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Остановленное время");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Прошла одна секунда!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "时间冻结");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "一秒钟过去了！");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			string TimeStop2 = Language.GetTextValue("Mods.Antiaris.TimeStop2", player.name);
			AntiarisPlayer aPlayer = Main.LocalPlayer.GetModPlayer<AntiarisPlayer>();
			if (player != Main.LocalPlayer)
				Main.LocalPlayer.AddBuff(ModContent.BuffType<FrozenTime2>(), 20);
			if (player.buffTime[buffIndex] > 550)
			{
				aPlayer.inversion = true;
			}
			else
			{
				aPlayer.inversion = false;
			}
			if (player.buffTime[buffIndex] == 0)
			{
				ModContent.GetInstance<AntiarisWorld>().frozenTime = false;
				Main.NewText(TimeStop2, 255, 255, 255);
				SoundEngine.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/TimeParadoxCrystal2"), player.position);
				if (player.name != "zadum4ivii")
				{
					player.AddBuff(ModContent.BuffType<CrystalRecharge>(), 18000);
				}
			}
			else
				ModContent.GetInstance<AntiarisWorld>().frozenTime = true;
		}
	}
}
