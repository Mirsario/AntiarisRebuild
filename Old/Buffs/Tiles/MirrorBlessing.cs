using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Tiles
{
	public class MirrorBlessing : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mirror's Blessing");
			Description.SetDefault("8% increased damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "镜之祝福");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 8% 伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Благословение зеркала");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "На 8% увеличивает урон");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeDamage += 0.08f;
			player.rangedDamage += 0.08f;
			player.thrownDamage += 0.08f;
			player.minionDamage += 0.08f;
			player.magicDamage += 0.08f;
		}
	}
}
