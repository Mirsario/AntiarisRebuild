﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
	public class SpecterFlame : ModProjectile
	{
		public override Color? GetAlpha(Color lightColor)
		{
			if (projectile.timeLeft < 30)
				projectile.alpha = (int)(byte.MaxValue - byte.MaxValue * (double)(projectile.timeLeft / 30f));
			return new Color(Main.DiscoR - projectile.alpha, Main.DiscoG - projectile.alpha, Main.DiscoB - projectile.alpha, 128 - projectile.alpha / 2);
		}

		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 30;
			projectile.tileCollide = false;
			projectile.timeLeft = 250;
			projectile.ignoreWater = true;
			projectile.alpha = 255;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Specter Flame");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пламя спектра");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虹彩火焰");
			Main.projFrames[projectile.type] = 4;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.frameCounter++;
			if (projectile.frameCounter >= 4)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= Main.projFrames[projectile.type])
				projectile.frame = 0;
			if (projectile.timeLeft > 30 && projectile.alpha > 0)
				projectile.alpha -= 12;
			if (projectile.timeLeft > 30 && projectile.alpha < 128 && Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				projectile.alpha = 128;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			Vector2 vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
			Vector2 vector2 = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
			float newMoveToX = vector2.X - vector.X;
			float newMoveToY = vector2.Y - vector.Y;
			float newDistance = (float)Math.Sqrt(newMoveToX * (double)newMoveToX + newMoveToY * (double)newMoveToY);
			float speed = 6.8f;
			projectile.velocity.X = (float)((projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
			projectile.velocity.Y = (float)((projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			if (player.active && (Vector2.Distance(player.Center, projectile.Center) < 25.0))
			{
				switch (Main.rand.Next(6))
				{
					case 0:
						player.AddBuff(ModContent.BuffType<SapphireEssence>(), 180, true);
						break;
					case 1:
						player.AddBuff(ModContent.BuffType<DiamondEssence>(), 180, true);
						break;
					case 2:
						player.AddBuff(ModContent.BuffType<AmethystEssence>(), 180, true);
						break;
					case 3:
						player.AddBuff(ModContent.BuffType<TopazEssence>(), 180, true);
						break;
					case 4:
						player.AddBuff(ModContent.BuffType<EmeraldEssence>(), 180, true);
						break;
					case 5:
						player.AddBuff(ModContent.BuffType<RubyEssence>(), 180, true);
						break;
				}
				projectile.Kill();
			}
			float ai2 = 0.5f;
			if (projectile.timeLeft < 120)
				ai2 = 1.1f;
			if (projectile.timeLeft < 60)
				ai2 = 1.6f;
			++projectile.ai[0];
			double ai = projectile.ai[0] / 180.0;
			for (float k = 0.0f; k < 3.0; k++)
				if (Main.rand.Next(3) == 0)
				{
					Dust dust = Main.dust[Dust.NewDust(projectile.Center, 0, 0, 261, 0.0f, -2.0f, 0, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 1.0f)];
					dust.position = projectile.Center + Vector2.UnitY.RotatedBy(k * 6.28318548202515 / 3.0 + projectile.ai[0], new Vector2()) * 10.0f;
					dust.noGravity = true;
					dust.velocity = projectile.DirectionFrom(dust.position);
					dust.scale = ai2;
					dust.fadeIn = 0.5f;
					dust.alpha = 200;
				}
		}
	}
}
