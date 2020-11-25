using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MagicChessboard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 42;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Chessboard");
			Tooltip.SetDefault("'An ancient artifact of pure magic. Befitting as a game of study.'\n150% increased magic damage\nIncreases maximum mana by 200");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "“棋盘”");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“纯粹的魔法。适合作为益智游戏。”\n1、增加 150% 魔法伤害\n2、增加 200 点最大魔力值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Магическая шахматная доска");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Древний артефакт истинной магии. Подходит, как игра для изучения.'\nУвеличивает магический урон на 150%\nУвеличивает максимальное количество маны на 200");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 200;
			player.magicDamage += 1.5f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.GraniteBlock, 32)
				.AddIngredient(ItemID.MarbleBlock, 32)
				.AddIngredient(null, "GranitePawn", 8)
				.AddIngredient(null, "MarblePawn", 8)
				.AddIngredient(null, "GraniteKnight", 1)
				.AddIngredient(null, "GraniteBishop", 1)
				.AddIngredient(null, "GraniteRook", 1)
				.AddIngredient(null, "GraniteQueen", 1)
				.AddIngredient(null, "GraniteKing", 1)
				.AddIngredient(null, "MarbleKnight", 1)
				.AddIngredient(null, "MarbleBishop", 1)
				.AddIngredient(null, "MarbleRook", 1)
				.AddIngredient(null, "MarbleQueen", 1)
				.AddIngredient(null, "MarbleKing", 1)
				.AddTile(114)
				.Register();
		}
	}
}
