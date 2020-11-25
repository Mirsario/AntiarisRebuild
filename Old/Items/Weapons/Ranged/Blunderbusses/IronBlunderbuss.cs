using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class IronBlunderbuss : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.DamageType = DamageClass.Ranged;
			item.width = 56;
			item.height = 18;
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
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "铁火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用火铳弹作为弹药");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Железный мушкетон");
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
				.AddIngredient(ItemID.IronBar, 10)
				.AddIngredient(ItemID.StoneBlock, 15)
				.AddTile(16)
				.Register();
		}
	}
}
