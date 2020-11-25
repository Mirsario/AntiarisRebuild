using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class CrystalBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.width = 14;
			item.maxStack = 999;
			item.height = 14;
			item.rare = ItemRarityID.LightRed;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 2f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 0, 6);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кристальная картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔晶火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于火铳");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<CrystalBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.CrystalShard)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
