using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class RubyEssence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ruby Essence");
			Description.SetDefault("Melee damage is increased by 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рубиновая эссенция");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Ближний урон увеличен на 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红宝石精华");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 10% 近战伤害");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.1f;
		}
	}
}
