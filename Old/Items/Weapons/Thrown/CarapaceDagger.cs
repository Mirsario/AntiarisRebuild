using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class CarapaceDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.thrown = true;
			item.width = 20;
			item.height = 44;
			item.noUseGraphic = true;
			item.useTime = 19;
			item.useAnimation = 19;
			item.shoot = ModContent.ProjectileType<CarapaceDagger>();
			item.shootSpeed = 11f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5f;
			item.value = Item.sellPrice(0, 0, 0, 18);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carapace Dagger");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Панцирный клинок");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "坚壳飞刀");
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(ItemID.ThrowingKnife, 50)
				.AddIngredient(null, "AntlionCarapace")
				.AddTile(16)
				.Register();
		}
	}
}
