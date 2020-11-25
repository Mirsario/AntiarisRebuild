using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
	public class HoneyRecharge : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Honey Recharge");
			Description.SetDefault("The honey badger must recharge to cover you once again");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовая перезарядка");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Медоед должен перезарядиться, чтобы вновь вас защитить");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			canBeCleared = false;
		}
	}
}