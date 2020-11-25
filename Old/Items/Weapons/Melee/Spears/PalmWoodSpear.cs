using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class PalmWoodSpear : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 7;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 35;
			item.useTime = 35;
			item.shootSpeed = 2f;
			item.knockBack = 10f;
			item.width = 52;
			item.height = 52;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<PalmWoodSpear>();
			item.value = Item.sellPrice(0, 0, 0, 21);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Spear");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "棕榈木矛");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Копье из пальмовой древесины");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PalmWood, 9)
				.AddTile(18)
				.Register();
		}
	}
}
