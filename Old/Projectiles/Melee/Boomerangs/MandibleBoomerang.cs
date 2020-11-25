using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Boomerangs
{
	public class MandibleBoomerang : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(106);
			aiType = 106;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mandible Boomerang");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮下颚回旋镖");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Челюстный бумеранг");
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}
	}
}
