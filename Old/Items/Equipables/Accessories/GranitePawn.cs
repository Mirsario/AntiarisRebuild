using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class GranitePawn : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 40;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
			item.maxStack = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Pawn");
			Tooltip.SetDefault("'One of the pieces of pure magic. Take the first step...'\nIncreases maximum mana by 20");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "花岗岩小卒棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。迈出第一步...”\n增加 20 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гранитная пешка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Сделай первый шаг...'\nУвеличивает максимальное количество маны на 20");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 20;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
