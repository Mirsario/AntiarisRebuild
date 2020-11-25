using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class EmeraldEssence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Emerald Essence");
			Description.SetDefault("Ranged damage is increased by 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Изумрудная эссенция");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Дальний урон увеличен на 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "翡翠精华");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 10% 远程伤害");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.rangedDamage += 0.1f;
		}
	}
}
