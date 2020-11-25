using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
	public class HealthyApplePie : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 24;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
			item.buffType = ModContent.BuffType<HealthElixir>();
			item.buffTime = 54000;
			item.value = Item.sellPrice(0, 0, 1, 20);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Healthy Apple Pie");
			Tooltip.SetDefault("Increases maximum health by 30");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "生命苹果派");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "生命最大值提升 30");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Полезный яблочный пирог");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное здоровье на 30");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "Apple", 10)
				.AddTile(17)
				.Register();
		}
	}
}
