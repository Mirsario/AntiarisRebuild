using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class CursedBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.width = 18;
			item.maxStack = 999;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 1f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 0, 8);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses\nDeals 20% of damage to nearby enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "咒火火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、用于火铳\n2、对附近的敌人造成 20% 的伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Проклятая картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов\nНаносит 20% урона ближайшим врагам");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<CursedBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.CursedFlame)
				.AddTile(134)
				.Register();
		}
	}
}
