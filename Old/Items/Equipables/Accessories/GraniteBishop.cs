using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class GraniteBishop : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 48;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Bishop");
			Tooltip.SetDefault("'One of the pieces of pure magic. Maintain focus, and calm your grips.'\nIncreases maximum mana by 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "花岗岩主教棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。保持专注，让你冷静下来。”\n增加 40 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гранитный слон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Сфокусируйся и успокойся.'\nУвеличивает максимальное количество маны на 40");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 5)
				.AddIngredient(ItemID.HellstoneBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
