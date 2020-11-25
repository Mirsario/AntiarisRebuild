using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class SnowOwl : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Snow Owl");
			Description.SetDefault("Sadly, it doesn't carry any letters!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "雪鹰");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "遗憾的是，它没有携带任何信件！");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Снежная сова");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Увы, она не не принесла никаких писем!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<AntiarisPlayer>(mod).snowOwl = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SnowOwl>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<SnowOwl>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}