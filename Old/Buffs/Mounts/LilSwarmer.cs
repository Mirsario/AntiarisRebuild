using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Mounts
{
	public class LilSwarmer : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lil' Swarmer");
			Description.SetDefault("Hold on tight while flying!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маленький муравьиный лев");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Крепко держитесь при полёте!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "小蚁狮");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "飞行时一定要牢牢抓住！");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<LilSwarmer>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
