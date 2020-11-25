using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
	public class BadgersResolve : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Badger's Resolve");
			Description.SetDefault("Increased health regeneration and reduced damage taken");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Барсучья решимость");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Повышенное восстановление здоровья и сниженный получаемый урон");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 10;
			player.endurance += 0.30f;
			if (player.buffTime[buffIndex] == 0)
			{
				player.AddBuff(ModContent.BuffType<HoneyRecharge>(), 1200);
			}
		}
	}
}