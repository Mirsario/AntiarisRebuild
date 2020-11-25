using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
	public class LeapingPotion : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.buffType = ModContent.BuffType<LeapingPotion>();
			item.buffTime = 7200;
			item.value = Item.sellPrice(0, 0, 2, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leaping Potion");
			Tooltip.SetDefault("Increases jump height\nAllows auto-jump");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "跃进药水");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、自身可以跳得更高\n2、按住空格键允许进行连续跳跃");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зелье прыгучести");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает высоту прыжка\nПозволяет автоматически прыгать");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater, 1)
				.AddIngredient(ItemID.Frog, 1)
				.AddIngredient(ItemID.Waterleaf, 1)
				.AddIngredient(ItemID.Moonglow, 1)
				.AddTile(13)
				.Register();
		}
	}
}
