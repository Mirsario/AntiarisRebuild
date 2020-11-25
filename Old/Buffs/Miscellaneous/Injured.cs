using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class Injured : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Injured");
			Description.SetDefault("Congratulations, you cut yourself");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "受伤");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "喜大普奔，你伤到了自己");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рана");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Поздравляем, вы порезали себя");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).injured = true;
		}
	}
}
