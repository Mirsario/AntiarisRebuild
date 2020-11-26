﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class SVDMG : ModItem
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
            item.damage = 86;
            item.DamageType = DamageClass.Ranged;
            item.width = 68;
            item.height = 32;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = ItemUseStyleID.Shoot;
            item.noMelee = true;
            item.knockBack = 4;
            item.rare = ItemRarityID.Red;
            item.shoot = ModContent.ProjectileType<Projectiles.Ranged.SplitBullet>();
            item.UseSound = SoundID.Item40;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 40f;
            item.value = Item.buyPrice(0, 17, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = ModContent.ProjectileType<Projectiles.Ranged.SplitBullet>();

            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 0.66f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, -2);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SDMG)
                .AddIngredient(ItemID.VortexBeater)
                .AddIngredient(ItemID.FragmentVortex, 14)
                .AddIngredient(ItemID.LunarBar, 12)
                .AddIngredient<Materials.WrathElement>(12)
                .AddTile(412)
                .Register();
        }
    }
}
