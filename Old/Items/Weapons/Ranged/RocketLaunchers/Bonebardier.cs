using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.RocketLaunchers
{
	public class Bonebardier : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 48;
			item.DamageType = DamageClass.Ranged;
			item.width = 64;
			item.height = 30;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 9;
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.RocketI;
			item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Rocket;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bonebardier");
			Tooltip.SetDefault("Uses rockets as ammo\nRockets that are shoot out from Bonebardier explode into several damaging bones");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "骸骨炮兵");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Костордир");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует ракеты в качестве патронов\nРакеты, выстреленные из Костордира, взрываются в несколько наносящих урон костей");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火箭作为弹药\n2、骸骨炮兵发射的火箭爆炸后会分裂成几个有杀伤性的骸骨");

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BonebardierBlueprint", 1)
				.AddIngredient(ItemID.Bone, 45)
				.AddRecipeGroup(RecipeGroupID.IronBar, 12)
				.AddIngredient(ItemID.IllegalGunParts, 1)
				.AddTile(16)
				.Register();
		}
	}
}
