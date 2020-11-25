using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class CherryBlossom : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 19;
			item.DamageType = DamageClass.Ranged;
			item.width = 68;
			item.height = 26;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.holdStyle = 3;
			item.shootSpeed = 12f;
			item.value = Item.sellPrice(0, 0, 65, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cherry Blossom");
			Tooltip.SetDefault("Uses buckshots as ammo\nBuckshots poison enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "樱花");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用火铳弹当做弹药\n发射可以使敌人中毒的火铳弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Цветущая вишня");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nКартечь отравляет врагов");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BlunderbussBase", 1)
				.AddIngredient(ItemID.Stinger, 12)
				.AddIngredient(ItemID.JungleSpores, 8)
				.AddIngredient(null, "NatureEssence", 10)
				.AddTile(18)
				.Register();
		}
	}
}
