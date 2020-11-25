using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
	public class SteelFeetPotion : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 24;
			item.useTurn = true;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.buffType = ModContent.BuffType<SteelFeetPotion>();
			item.buffTime = 18000;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 2, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Feet Potion");
			Tooltip.SetDefault("Increases height at which you take damage from falling\nReduces fall damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "钢踵药水");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、坠落伤害所需要的高度上升\n2、减少你承受的坠落伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зелье стальных пят");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает высоту, с которой вы получаете урон от падения\nУменьшает урон от падения");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater, 1)
				.AddRecipeGroup(RecipeGroupID.IronBar, 5)
				.AddIngredient(ItemID.Waterleaf, 3)
				.AddTile(13)
				.Register();
		}
	}
}
