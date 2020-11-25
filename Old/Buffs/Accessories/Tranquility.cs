using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
	public class Tranquility : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tranquility");
			Description.SetDefault("Decreases damage taken by 15%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Спокойствие");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Уменьшает полученный урон на 15%");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.endurance += 0.15f;
		}
	}
}
