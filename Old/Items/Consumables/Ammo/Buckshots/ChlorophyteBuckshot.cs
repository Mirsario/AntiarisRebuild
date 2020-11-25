using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class ChlorophyteBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 16;
			item.width = 18;
			item.maxStack = 999;
			item.height = 18;
			item.rare = ItemRarityID.Lime;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 1f;
			item.ammo = ModContent.ItemType<Buckshot>();
			item.value = Item.sellPrice(0, 0, 0, 10);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses\nChases after your enemy and bounces from blocks");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "叶绿火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、用于火铳\n2、遇到方块反弹并且追赶你的敌人");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Спектральная картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов\nСледует за врагами и отскакивает от блоков");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<ChlorophyteBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.ChlorophyteBar)
				.AddTile(134)
				.Register();
		}
	}
}
