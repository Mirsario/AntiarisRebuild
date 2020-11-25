using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Endless
{
	public class EndlessDartPack : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 10;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 22;
			item.width = 26;
			item.shoot = ModContent.ProjectileType<Buckshot>();
			item.shootSpeed = 5f;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Green;
			item.ammo = AmmoID.Dart;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Dart Pack");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "无尽飞镖包");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Бесконечный комплект дротиков");
		}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PoisonDart, 3996)
				.AddTile(125)
				.Register();
		}
	}
}
