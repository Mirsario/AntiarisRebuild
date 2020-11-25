using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Pets
{
	public class Snowflake : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BabySkeletronHead);
			aiType = ProjectileID.BabySkeletronHead;
			projectile.width = 46;
			projectile.height = 46;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			var drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
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
			bool flag = projectile.type == ModContent.ProjectileType<Snowflake>();
			AntiarisPlayer modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (flag)
			{
				if (player.dead)
				{
					modPlayer.snowflake = false;
				}
				if (modPlayer.snowflake)
				{
					projectile.timeLeft = 2;
				}
			}
			if (Main.rand.Next(3) == 0)
			{
				int i = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, projectile.velocity.X, projectile.velocity.Y);
				Main.dust[i].noGravity = true;
			}
		}
	}
}