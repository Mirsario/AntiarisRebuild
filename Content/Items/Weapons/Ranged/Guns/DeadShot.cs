using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class DeadShot : ModItem
    {
        /*public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(Mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, Mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}*/

        public override void SetDefaults()
        {
            item.damage = 168;
            item.DamageType = DamageClass.Ranged;
            item.width = 98;
            item.height = 28;
            item.useTime = 65;
            item.useAnimation = 65;
            item.useStyle = ItemUseStyleID.Shoot;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = ItemRarityID.Cyan;
            item.UseSound = new ModSoundStyle(Mod.Name, "Assets/Sounds/Items/DwarfShark", 0);
            item.value = Item.buyPrice(0, 8, 50, 0);
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.BloodyBullet>();
            item.shootSpeed = 220f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<Projectiles.Ranged.BloodyBullet>();

            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "DwarfShark")
                .AddIngredient(ItemID.IllegalGunParts)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient<Materials.BloodDroplet>(28)
                .AddIngredient<Materials.WrathElement>(6)
                .AddTile(134)
                .Register();
        }
    }
}
