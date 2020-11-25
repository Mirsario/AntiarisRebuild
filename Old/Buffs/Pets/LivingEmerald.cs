using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class LivingEmerald : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Living Emerald");
			Description.SetDefault("It's pretty bouncy!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "活翡翠");
			Description.AddTranslation((int)GameCulture.CultureName.Chinese, "非常有弹性！");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Живой изумруд");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Он неплохо прыгает!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<AntiarisPlayer>(mod).livingEmerald = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<LivingEmerald>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<LivingEmerald>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}