using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class SapphireEssence : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sapphire Essence");
			Description.SetDefault("Magic damage is increased by 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сапфировая эссенция");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Магический урон увеличен на 10%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蓝宝石精华");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 10% 魔法伤害");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.magicDamage += 0.1f;
		}
	}
}
