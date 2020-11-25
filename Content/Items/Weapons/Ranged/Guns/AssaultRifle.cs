using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class AssaultRifle : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 16;
			item.DamageType = DamageClass.Ranged;
			item.width = 60;
			item.height = 22;
			item.useAnimation = 12;
			item.useTime = 6;
			item.reuseDelay = 18;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item31;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.shootSpeed = 8f;
			item.value = Item.buyPrice(0, 65, 0, 0);
			item.useAmmo = AmmoID.Bullet;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return !(player.itemAnimation < item.useAnimation - 2);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Assault Rifle");
			Tooltip.SetDefault("Two round burst\nOnly consumes ammo for first shot");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "突击步枪");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "消耗一颗子弹，连续发射三颗子弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Штурмовая винтовка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Очередь из двух пуль\nБоеприпасы расходуются только на первый выстрел");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, 1);
		}
	}
}
