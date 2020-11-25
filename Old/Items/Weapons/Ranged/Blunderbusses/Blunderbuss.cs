using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class Blunderbuss : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 5;
			item.DamageType = DamageClass.Ranged;
			item.width = 58;
			item.height = 16;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 12f;
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用火铳弹当做弹药");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мушкетон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.StoneBlock, 15)
				.AddTile(18)
				.Register();
		}
	}
}
