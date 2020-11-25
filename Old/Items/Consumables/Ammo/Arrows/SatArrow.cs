using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
	public class SatArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 50;
			item.width = 18;
			item.shoot = ModContent.ProjectileType<SatArrow>();
			item.shootSpeed = 12f;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.Yellow;
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sat's Arrow");
			Tooltip.SetDefault("A fast arrow that's unaffected by gravity\nInflicts targets with shadowflame\nSummons shadow flames that home into enemies when hitting blocks or enemies if shot from Sat's Bow");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "Sat的弓箭");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、高速且不受重力影响的弓箭\n2、受到该弓箭攻击的敌人会被暗影火灼烧\n3、如果使用<Sat的弓>接触物体爆炸后会召唤暗影火");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Стрела Сата");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Быстро движущаяся стрела, не подверженная гравитации\nНакладывает на врагов теневой огонь\nПризывает теневые огоньки, если выстрелена из Лука Сата");
		}

		public override void AddRecipes()
		{
			CreateRecipe(333)
				.AddIngredient(ItemID.WoodenArrow, 333)
				.AddIngredient(null, "Shadowflame")
				.AddIngredient(null, "WrathElement")
				.AddTile(412)
				.Register();
		}
	}
}
