using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
	public class ThoriumBlunderbuss : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.DamageType = DamageClass.Ranged;
			item.width = 62;
			item.height = 28;
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
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useAmmo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorium Blunderbuss");
			Tooltip.SetDefault("Uses buckshots as ammo\nShoots a piercing buckshot");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "瑟银火铳");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、使用火铳弹作为弹药\n2、发射一枚锋利的火铳弹");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ториевый мушкетон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует картечь в качестве патронов\nВыстреливает пробивающей картечью");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			if (AntiarisMod.Thorium != null && ModContent.TryGet<ModItem>(AntiarisMod.Thorium.Name, "A", out var anItem))
			{
				CreateRecipe()
					.AddIngredient(anItem.Type, 14)
					.AddIngredient(null, "BlunderbussBase", 1)
					.AddIngredient(ItemID.StoneBlock, 10)
					.AddTile(16)
					.Register();
			}
		}
	}
}
