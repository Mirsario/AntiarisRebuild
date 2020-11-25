using Terraria;
using Terraria.ModLoader;

namespace Antiaris
{
	class ProjectileStop : GlobalProjectile
	{
		private int ProjDamage;
		public int Tick;

		public override bool InstancePerEntity => true;

		public override bool PreAI(Projectile projectile)
		{
			Player player = Main.LocalPlayer;
			Tick++;
			if (projectile.damage != 0)
			{
				ProjDamage = projectile.damage;
			}
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime && Tick >= 4 && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != ModContent.ProjectileType<Warbanner>() && projectile.type != ModContent.ProjectileType<Vanguard>() && projectile.type != ModContent.ProjectileType<VoltCharge>() && projectile.type != ModContent.ProjectileType<TimeWave>())
			{
				projectile.timeLeft++;
				if (!projectile.friendly && projectile.aiStyle != 113)
				{
					projectile.damage = 0;
				}
				return false;
			}
			else
			{
				if (!projectile.friendly && projectile.damage != ProjDamage && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != ModContent.ProjectileType<Warbanner>() && projectile.type != ModContent.ProjectileType<Vanguard>() && projectile.type != ModContent.ProjectileType<VoltCharge>())
				{
					projectile.damage = ProjDamage;
				}
				return true;
			}
		}

		public override bool ShouldUpdatePosition(Projectile projectile)
		{
			Player player = Main.LocalPlayer;
			if (ModContent.GetInstance<AntiarisWorld>().frozenTime && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != ModContent.ProjectileType<Warbanner>() && projectile.type != ModContent.ProjectileType<Vanguard>() && projectile.type != ModContent.ProjectileType<VoltCharge>())
			{
				return false;
			}
			else
			{
				return true;
			}
			return true;
		}
	}
}