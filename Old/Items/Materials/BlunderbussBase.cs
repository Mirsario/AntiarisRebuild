using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
	public class BlunderbussBase : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 70;
			item.height = 18;
			item.rare = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blunderbuss Base");
			Tooltip.SetDefault("Used to make blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "火铳框架");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于制造火铳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Основа мушкетона");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется для создания мушкетонов");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Flammable);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 20)
				.AddTile(18)
				.Register();
		}
	}
}
