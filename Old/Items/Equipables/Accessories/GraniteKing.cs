using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class GraniteKing : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 52;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite King");
			Tooltip.SetDefault("'One of the pieces of pure magic. Never falter, no matter what.'\nIncreases maximum mana by 100");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "花岗岩国王棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。无论发生什么事，都不要犹豫。”\n增加 100 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гранитный король");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Никогда не колебись, несмотря ни на что.'\nУвеличивает максимальное количество маны на 100");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 100;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 5)
				.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
