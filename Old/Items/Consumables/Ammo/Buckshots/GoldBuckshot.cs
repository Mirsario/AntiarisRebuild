using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class GoldBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 6;
			item.width = 14;
			item.maxStack = 999;
			item.height = 14;
			item.rare = ItemRarityID.White;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 2f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 1, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "金火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于火铳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Золотая картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<GoldBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.GoldBar, 1)
				.AddTile(16)
				.Register();
		}
	}
}
