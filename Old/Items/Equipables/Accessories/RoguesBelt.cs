using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class RoguesBelt : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = ItemRarityID.Blue;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rogue's Belt");
			Tooltip.SetDefault("15% not to consume thrown item");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "恶棍腰带");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "减少投掷武器 15% 的消耗");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Пояс жулика");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Уменьшает потребляемость метательных оружий на 15%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).thrownCost += 15;
			player.GetModPlayer<AntiarisPlayer>(mod).roguesBelt = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ThrowingKnife, 25)
				.AddIngredient(ItemID.Leather, 4)
				.AddRecipeGroup(RecipeGroupID.IronBar, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
