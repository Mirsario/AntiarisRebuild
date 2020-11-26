using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class FungiBoomgun : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 9;
            item.DamageType = DamageClass.Ranged;
            item.width = 66;
            item.height = 28;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.Shoot;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 3f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<Projectiles.Ranged.BulletShroom>();

            for (int i = 0; i < 3; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
        }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlareGun, 1)
                .AddIngredient(ItemID.Boomstick, 1)
                .AddIngredient(ItemID.GlowingMushroom, 15)
                .AddRecipeGroup(RecipeGroupID.IronBar, 8)
                .AddTile(18)
                .Register();
        }
    }
}
