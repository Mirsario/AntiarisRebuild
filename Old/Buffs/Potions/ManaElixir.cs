using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
	public class ManaElixir : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mana Elixir");
			Description.SetDefault("Increases maximum mana by 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔力饮料");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "魔力最大值提升 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Эликсир маны");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное количество маны на 40");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statManaMax2 += 40;
		}
	}
}
