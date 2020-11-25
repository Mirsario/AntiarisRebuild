using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class DwarfShark : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 155;
			item.DamageType = DamageClass.Ranged;
			item.width = 64;
			item.height = 22;
			item.useTime = 35;
			item.useAnimation = 35;
			item.crit = item.crit + 20;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = new ModSoundStyle(Mod.Name, "Assets/Sounds/Items/DwarfShark", 0);
			item.value = Item.buyPrice(0, 8, 50, 0);
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.shootSpeed = 3f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dwarf Shark");
			Tooltip.SetDefault("Shoots a powerful, high velocity bullet\n<right> to zoom out\n33% chance to not consume ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "侏儒鲨");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、发射一发强大的高速弹。\n2、点击鼠标 <right> 键观察远处。\n3、33%的几率不消耗弹药。");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Карликовая акула");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Стреляет убойной, высокоскоростной пулей\n<right> для приближения\n33% шанс не потратить пулю");
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
			return true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SniperRifle)
				.AddIngredient(ItemID.Minishark)
				.AddIngredient(ItemID.IllegalGunParts)
				.AddTile(134)
				.Register();
		}
	}
}