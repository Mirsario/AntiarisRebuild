using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
	public class ManaElixir : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 28;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.buffType = ModContent.BuffType<ManaElixir>();
			item.buffTime = 54000;
			item.value = Item.sellPrice(0, 0, 1, 20);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Elixir");
			Tooltip.SetDefault("Increases maximum mana by 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔力饮料");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "魔力最大值提升 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Эликсир маны");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное количество маны на 40");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.GlowingMushroom)
				.AddIngredient(ItemID.Moonglow)
				.AddIngredient(ItemID.Blinkroot)
				.AddTile(13)
				.Register();
		}
	}
}
