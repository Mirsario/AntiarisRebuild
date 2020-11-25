using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
	public class PurpleCrystalBullet : ModItem
	{
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void SetDefaults()
		{
			item.damage = 11;
			item.DamageType = DamageClass.Ranged;
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 5.0f;
			item.value = Item.sellPrice(0, 0, 0, 80);
			item.rare = ItemRarityID.Pink;
			item.shoot = ModContent.ProjectileType<PurpleCrystalBullet>();
			item.shootSpeed = 8.0f;
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple Crystal Bullet");
			Tooltip.SetDefault("Splits into two bullets flying in a random direction");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Фиолетовая кристальная пуля");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Разрывается в две пули, летящие в случайном направлении");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "紫水晶弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "可以分裂成两个随机方向飞行的子弹");
		}

		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(null, "PurpleBigCrystal", 1)
				.AddIngredient(ItemID.MusketBall, 100)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
