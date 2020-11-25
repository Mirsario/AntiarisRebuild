using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class ShadowflameCandle : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shadowflame Candle");
			Description.SetDefault("A shadow candle is following you");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火蜡烛");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火蜡烛在追随着你");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Свеча теневого пламени");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Свеча теневого пламени следует за вами");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<AntiarisPlayer>(mod).shadowflameCandle = true;
			bool spawned = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<ShadowflameCandle>()] > 0)
				spawned = false;
			if (!spawned || player.whoAmI != Main.myPlayer)
				return;
			Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0.0f, 0.0f, ModContent.ProjectileType<ShadowflameCandle>(), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
		}
	}
}