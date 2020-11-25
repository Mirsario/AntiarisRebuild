using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Tiles
{
	public class InnerZen : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Inner Zen");
			Description.SetDefault("15% increased health restored by healing potions");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "内禅");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 15% 生命药水增益数值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Внутреннее спокойствие");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает здоровье, восстанавливаемое зельями лечения, на 15%");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).healingBonus = true;
		}
	}
}
