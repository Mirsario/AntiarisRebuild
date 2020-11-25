using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Legs)]
	public class DisciplePants : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.rare = ItemRarityID.Blue;
			item.defense = 2;
			item.value = Item.sellPrice(0, 0, 12, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Disciple's Pants");
			Tooltip.SetDefault("Increases movement speed");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "门徒护腿");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加移动速度");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Штаны ученика");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает скорость передвижения");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RuneStone", 2)
				.AddIngredient(ItemID.Silk, 2)
				.AddTile(86)
				.Register();
		}
	}
}
