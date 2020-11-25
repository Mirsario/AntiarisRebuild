using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Body)]
	public class DiscipleRobe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
			item.value = Item.sellPrice(0, 0, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Disciple's Robe");
			Tooltip.SetDefault("5% increased magic damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "门徒法袍");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "魔法伤害增加 5%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Роба ученика");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает магический урон на 5%");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RuneStone", 5)
				.AddIngredient(ItemID.Silk, 5)
				.AddTile(86)
				.Register();
		}
	}
}
