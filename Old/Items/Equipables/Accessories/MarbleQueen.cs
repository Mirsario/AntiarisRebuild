using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MarbleQueen : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 50;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Queen");
			Tooltip.SetDefault("'One of the pieces of pure magic. Lose yourself, and find what was once lost.'\n25% increased magic damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大理石皇后棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。迷失自我，找回曾经失去的事物。”\n增加 25% 魔法伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мраморная королева");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Потеряй себя и узнай, что было однажды утеряно.'\nУвеличивает магический урон на 25%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MarbleBlock, 5)
				.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
