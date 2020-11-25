using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Bonuses
{
	public class BlazingBrazier : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.createTile = ModContent.TileType<BlazingBrazier>();
			//item.createTile = ModContent.TileType<Turret>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Brazier");
			Tooltip.SetDefault("Increases movement speed for nearby players");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "不灭篝火");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在其附近的玩家增加移动速度");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пылающая жаровня");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает скорость передвижения для ближайших игроков");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 6)
				.AddIngredient(null, "BlazingHeart")
				.Register();
		}
	}
}