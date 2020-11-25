using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class StoneBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 3;
			item.width = 14;
			item.maxStack = 999;
			item.height = 14;
			item.rare = ItemRarityID.White;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 2f;
			item.ammo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "石质火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于火铳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Каменная картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<StoneBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(7)
				.AddIngredient(ItemID.StoneBlock, 1)
				.AddTile(18)
				.Register();
		}
	}
}
