using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Bullets
{
	public class ShadowflameBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 13;
			item.DamageType = DamageClass.Ranged;
			item.width = 12;
			item.height = 12;
			item.knockBack = 4;
			item.rare = ItemRarityID.Pink;
			item.maxStack = 999;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<ShadowflameBullet>();
			item.shootSpeed = 5f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.ammo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Bullet");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пуля теневого пламени");
		}

		public override void AddRecipes()
		{
			CreateRecipe(70)
				.AddIngredient(ItemID.MusketBall, 70)
				.AddIngredient(null, "Shadowflame")
				.AddTile(134)
				.Register();
		}
	}
}
