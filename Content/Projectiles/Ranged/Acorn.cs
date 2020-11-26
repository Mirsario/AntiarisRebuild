using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Projectiles.Ranged
{
	public class Acorn : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.DamageType = DamageClass.Ranged;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                SoundEngine.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            }
        }
    }
}
