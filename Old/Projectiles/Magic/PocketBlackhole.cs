using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class PocketBlackhole : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 26;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.magic = true;
			projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pocket Blackhole");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "袖珍黑洞");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Карманная чёрная дыра");
			Main.projFrames[projectile.type] = 5;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			//from vanilla
			Player owner = null;
			if (projectile.owner != -1)
			{
				owner = Main.player[projectile.owner];
			}
			else if (projectile.owner == 255)
			{
				owner = Main.LocalPlayer;
			}
			Player player = owner;
			float num1 = 1.570796f;
			Vector2 vector2_1 = player.RotatedRelativePoint(player.MountedCenter, true);
			float num2 = 30f;
			if (projectile.ai[0] > 90.0)
				num2 = 15f;
			if (projectile.ai[0] > 120.0)
				num2 = 5f;
			++projectile.ai[0];
			++projectile.ai[1];
			bool flag1 = false;
			if (projectile.ai[0] % (double)num2 == 0.0)
				flag1 = true;
			int num3 = 10;
			bool flag2 = false;
			if (projectile.ai[0] % (double)num2 == 0.0)
				flag2 = true;
			if (projectile.ai[1] >= 1.0)
			{
				projectile.ai[1] = 0.0f;
				flag2 = true;
				if (Main.myPlayer == projectile.owner)
				{
					float num4 = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					Vector2 vector2_2 = vector2_1;
					Vector2 vector2_3 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - vector2_2;
					if (player.gravDir == -1.0)
						vector2_3.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector2_2.Y;
					Vector2 vector2_4 = Vector2.Normalize(vector2_3);
					if (float.IsNaN(vector2_4.X) || float.IsNaN(vector2_4.Y))
						vector2_4 = -Vector2.UnitY;
					vector2_4 = Vector2.Normalize(Vector2.Lerp(vector2_4, Vector2.Normalize(projectile.velocity), 0.92f));
					vector2_4 *= num4;
					if (vector2_4.X != (double)projectile.velocity.X || vector2_4.Y != (double)projectile.velocity.Y)
						projectile.netUpdate = true;
					projectile.velocity = vector2_4;
				}
			}
			++projectile.frameCounter;
			if (projectile.frameCounter >= (projectile.ai[0] < 120.0 ? 7 : 1))
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 5)
					projectile.frame = 0;
			}
			if (projectile.soundDelay <= 0)
			{
				projectile.soundDelay = num3;
				projectile.soundDelay *= 2;
				if (projectile.ai[0] != 1.0)
					SoundEngine.PlaySound(SoundID.Item15, projectile.position);
			}
			if (flag2 && Main.myPlayer == projectile.owner)
			{
				bool flag3 = !flag1 || player.CheckMana(player.inventory[player.selectedItem].mana, true, false);
				if (player.channel && flag3 && !player.noItems && !player.CCed)
				{
					if (projectile.ai[0] == 1.0)
					{
						Vector2 center = projectile.Center;
						Vector2 vector2_2 = Vector2.Normalize(projectile.velocity);
						if (float.IsNaN(vector2_2.X) || float.IsNaN(vector2_2.Y))
							vector2_2 = -Vector2.UnitY;
						int damage = 35;
						for (int index = 0; index < 7; ++index)
							Projectile.NewProjectile(center.X, center.Y, vector2_2.X, vector2_2.Y, ModContent.ProjectileType<PocketBlackholeBeam>(), damage, projectile.knockBack, projectile.owner, index, projectile.whoAmI);
						projectile.netUpdate = true;
					}
				}
				else
					projectile.Kill();
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = projectile.velocity.ToRotation() + num1;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * (double)projectile.direction, projectile.velocity.X * (double)projectile.direction);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Player owner = null;
			if (projectile.owner != -1)
			{
				owner = Main.player[projectile.owner];
			}
			else if (projectile.owner == 255)
			{
				owner = Main.LocalPlayer;
			}
			Player player = owner;
			Vector2 mountedCenter = player.MountedCenter;
			Color color = Lighting.GetColor((int)(projectile.position.X + projectile.width * 0.5) / 16, (int)((projectile.position.Y + projectile.height * 0.5) / 16.0));
			if (projectile.hide && !ProjectileID.Sets.DontAttachHideToAlpha[projectile.type])
				color = Lighting.GetColor((int)mountedCenter.X / 16, (int)(mountedCenter.Y / 16.0));
			SpriteEffects effects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
				effects = SpriteEffects.FlipHorizontally;
			Texture2D texture = Main.projectileTexture[projectile.type];
			int height = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int y = height * projectile.frame;
			Vector2 position = (projectile.position + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition).Floor();
			if (player.shroomiteStealth && player.inventory[player.selectedItem].ranged)
			{
				float num1 = player.stealth;
				if (num1 < 0.03)
					num1 = 0.03f;
				double num2 = (1.0 + num1 * 10.0) / 11.0;
				color *= num1;
			}
			if (player.setVortex && player.inventory[player.selectedItem].ranged)
			{
				float num1 = player.stealth;
				if (num1 < 0.03)
					num1 = 0.03f;
				double num2 = (1.0 + num1 * 10.0) / 11.0;
				color = color.MultiplyRGBA(new Color(Vector4.Lerp(Vector4.One, new Vector4(0.16f, 0.12f, 0.0f, 0.0f), 1f - num1)));
			}
			Main.spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(0, y, texture.Width, height)), projectile.GetAlpha(color), projectile.rotation, new Vector2(texture.Width / 2f, height / 2f), projectile.scale, effects, 0.0f);
			float num3 = (float)(Math.Cos(6.28318548202515 * (projectile.ai[0] / 30.0)) * 2.0 + 2.0);
			if (projectile.ai[0] > 120.0)
				num3 = 4f;
			for (float num1 = 0.0f; num1 < 4.0; ++num1)
				Main.spriteBatch.Draw(texture, position + Vector2.UnitY.RotatedBy(num1 * 6.28318548202515 / 4.0, new Vector2()) * num3, new Rectangle?(new Rectangle(0, y, texture.Width, height)), projectile.GetAlpha(color).MultiplyRGBA(new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0)) * 0.03f, projectile.rotation, new Vector2(texture.Width / 2f, height / 2f), projectile.scale, effects, 0.0f);
			return false;
		}
	}
}
