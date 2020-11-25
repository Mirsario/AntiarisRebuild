using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Endless
{
	public class EndlessRocketSilo : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 40;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 36;
			item.width = 38;
			item.shoot = ProjectileID.None;
			item.shootSpeed = 5f;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Green;
			item.ammo = 771;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Rocket Silo");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "无尽火箭箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Бесконечный комплект ракет");
		}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RocketI, 3996)
				.AddTile(125)
				.Register();
		}
	}
}
