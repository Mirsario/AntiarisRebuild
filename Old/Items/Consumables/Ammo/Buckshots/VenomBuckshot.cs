using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class VenomBuckshot : ModItem
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
			item.value = Item.sellPrice(0, 0, 0, 9);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Venom Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses\nSlows enemies down");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "剧毒火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、用于火铳\n2、减缓敌人的移动速度");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Отравленная картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов\nЗамедляет врагов");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.Ranged.Buckshots.VenomBuckshot>();
		}

		public override void AddRecipes()
			=> CreateRecipe(50)
				.AddIngredient(ModContent.ItemType<Buckshot>(), 50)
				.AddIngredient(ItemID.VialofVenom)
				.AddTile(TileID.MythrilAnvil)
				.Register();
	}
}
