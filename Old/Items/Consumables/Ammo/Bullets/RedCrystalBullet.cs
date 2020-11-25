using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
	public class RedCrystalBullet : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.DamageType = DamageClass.Ranged;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 7.0f;
			item.value = Item.sellPrice(0, 0, 0, 80);
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<RedCrystalBullet>();
			item.shootSpeed = 6.0f;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Crystal Bullet");
			Tooltip.SetDefault("More power at the cost of piercing ability");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Красная кристальная пуля");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Больше силы, но меньше пробиваемости");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红水晶弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "以穿透力为代价的更高伤害");
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(null, "RedBigCrystal", 1)
				.AddIngredient(ItemID.MusketBall, 100)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
