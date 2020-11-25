using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Legs)]
	public class SorcererPants : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.rare = ItemRarityID.Green;
			item.defense = 4;
			item.value = Item.sellPrice(0, 0, 21, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer's Pants");
			Tooltip.SetDefault("Increases movement speed");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "巫师护腿");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、魔法伤害增加 5%\n2、魔法致命一击概率增加 3%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Штаны колдуна");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает скорость передвижения");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.08f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "DisciplePants", 1)
				.AddIngredient(null, "WrathElement", 5)
				.AddIngredient(ItemID.ShadowScale, 5)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "DisciplePants", 1)
				.AddIngredient(null, "WrathElement", 5)
				.AddIngredient(ItemID.TissueSample, 5)
				.AddTile(16)
				.Register();
		}
	}
}
