using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class ArmyRifle : ModItem
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            item.damage = 24;
            item.DamageType = DamageClass.Ranged;
            item.width = 74;
            item.height = 28;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.Shoot;
            item.noMelee = true;
            item.knockBack = 4;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 8f;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.useAmmo = AmmoID.Bullet;
        }

        public override void UseStyle(Player player)
        {
            ++timer;
            if (timer % 7 == 0)
            {
                item.useTime--;
                item.useAnimation--;
                item.shootSpeed += 2f;
                if (item.useTime <= 2)
                {
                    item.useTime = 30;
                    item.shootSpeed = 8f;
                    item.useAnimation = 30;
                }
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 4);
        }
    }
}
