using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class GraniteKnight : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 40;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Knight");
			Tooltip.SetDefault("'One of the pieces of pure magic. Make your stand, and prove yourself.'\nIncreases maximum mana by 40");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "花岗岩骑士棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。让你站起来，证明你自己。”\n增加 40 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Гранитный рыцарь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Стой смело и прояви себя.'\nУвеличивает максимальное количество маны на 40");
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
