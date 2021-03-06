﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class Torrent : ModProjectile
	{
		private int hellLayer => Main.maxTilesY - 200;

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 6;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.aiStyle = 1;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.timeLeft = 100;
			projectile.extraUpdates = 2;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torrent");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Поток");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "湍流");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ProjectileTags.Extinguisher);
		}*/

		public override void AI()
		{
			if (projectile.timeLeft <= 60)
				projectile.velocity.Y += 0.075f;
			for (int k = 0; k < 3; k++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 172, 0.0f, 0.0f, 100, new Color(), 1.2f);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.3f;
				Main.dust[dust].velocity += projectile.velocity * 0.5f;
				Main.dust[dust].position.X -= projectile.velocity.X / 3f * k;
				;
				Main.dust[dust].position.Y -= projectile.velocity.Y / 3f * k;
			}
			if (Main.rand.NextBool(1, 8))
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X + 6.0f, projectile.position.Y + 6.0f), projectile.width - 12, projectile.height - 12, 172, 0.0f, 0.0f, 100, new Color(), 0.72f);
				Main.dust[dust].velocity *= 0.5f;
				Main.dust[dust].velocity += projectile.velocity * 0.5f;
			}
			if (projectile.lavaWet)
				projectile.Kill();
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (!target.boss)
				target.AddBuff(ModContent.BuffType<Deceleration>(), 240, false);
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.wet)
				damage *= 2;
			if (Main.player[projectile.owner].position.Y > this.hellLayer * 16)
				damage /= 2;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = -1; k <= 1; k += 2)
				Projectile.NewProjectile(projectile.Center, Vector2.Zero - new Vector2(-0.16f * -(float)k, 2.64f), mod.ProjectileType("Copy" + GetType().Name), (int)(projectile.damage * 0.8f), projectile.knockBack, projectile.owner);
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 21);
		}
	}
}
