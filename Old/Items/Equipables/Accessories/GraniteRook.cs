using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class GraniteRook : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 38;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Rook");
			Tooltip.SetDefault("'One of the pieces of pure magic. Guard those who act in your stead.'\nIncreases maximum mana by 60");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "花岗岩战车棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。保护那些替你行事的人。”\n增加 60 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гранитный слон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Защищает тех, кто действует вместо вас.'\nУвеличивает максимальное количество маны на 60");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 60;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 5)
				.AddIngredient(ItemID.HallowedBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
