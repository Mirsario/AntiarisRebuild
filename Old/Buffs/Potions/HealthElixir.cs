using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
	public class HealthElixir : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Health Elixir");
			Description.SetDefault("Increases maximum health by 30");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "益寿饮料");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "生命最大值提升30，益寿又延年~");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Эликсир здоровья");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное здоровье на 30");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statLifeMax2 += 30;
		}
	}
}
