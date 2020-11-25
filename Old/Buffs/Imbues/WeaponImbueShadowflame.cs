using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Imbues
{
	public class WeaponImbueShadowflame : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Weapon Imbue: Shadowflame");
			Description.SetDefault("Melee attacks inflict shadowflame on enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "武器灌注：暗影火");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "近战攻击可以使敌人被暗影火点燃");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Насыщение оружия: теневое пламя");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Ближние атаки накладывают на врагов теневое пламя");
			Main.meleeBuff[Type] = true;
			Main.persistentBuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.shadowflameImbue = true;
		}
	}
}
