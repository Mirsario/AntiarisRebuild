using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class PrivateerCannon : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.DamageType = DamageClass.Ranged;
			item.width = 76;
			item.height = 28;
			item.useTime = 25;
			item.useAnimation = 25;
			item.shoot = ModContent.ProjectileType<Projectiles.Ranged.RoyalCannonball>();
			item.shootSpeed = 15f;
			item.useStyle = ItemUseStyleID.Shoot;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Privateer Cannon");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "私掠者的火炮");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пушка капера");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<Materials.RoyalWeaponParts>(6)
				.AddTile(16)
				.Register();
		}
	}
}
