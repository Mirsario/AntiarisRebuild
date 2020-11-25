using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class TopazEssence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Topaz Essence");
			Description.SetDefault("Throwing damage is increased by 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Топазовая эссенция");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Метательный урон увеличен на 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "黄玉精华");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 10% 投掷伤害");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.1f;
		}
	}
}
