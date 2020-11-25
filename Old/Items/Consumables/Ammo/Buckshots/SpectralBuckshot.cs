using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class SpectralBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 16;
			item.width = 18;
			item.maxStack = 999;
			item.height = 18;
			item.rare = ItemRarityID.Yellow;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 1f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 0, 9);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectral Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses\nCan go through blocks");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "幽灵火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、用于火铳\n2、允许穿墙");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Спектральная картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов\nМожет проходить через блоки");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<SpectralBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.Ectoplasm)
				.AddTile(134)
				.Register();
		}
	}
}
