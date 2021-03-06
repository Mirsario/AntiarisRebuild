﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Projectiles.Enemies
{
	public class CalmnessEnergy : ModProjectile
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.timeLeft = 176;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calmness Energy");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宁静能量");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Энергия спокойствия");
			Main.projFrames[projectile.type] = 4;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 6)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= Main.projFrames[projectile.type])
				projectile.frame = 0;
			Player player = Main.LocalPlayer;
			if (player.active && (Vector2.Distance(player.Center, projectile.Center) < 35.0))
			{
				int number = 0;
				number = Item.NewItem(projectile.position, projectile.Size, ModContent.ItemType<TranquilityElement>(), 1, false, 0, false, false);
				if (Main.netMode == NetmodeID.MultiplayerClient && number >= 0)
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				projectile.Kill();
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 50; k++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 211, 0.0f, -2.0f, 0, new Color(), 2.0f);
				Main.dust[dust].noGravity = true;
				Dust dust1 = Main.dust[dust];
				dust1.position.X = dust1.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
				Dust dust2 = Main.dust[dust];
				dust2.position.Y = dust2.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
				if (Main.dust[dust].position != projectile.Center)
					Main.dust[dust].velocity = projectile.DirectionTo(Main.dust[dust].position) * 1.0f;
			}
			SoundEngine.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		}
	}
}
