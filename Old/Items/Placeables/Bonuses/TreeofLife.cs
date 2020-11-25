using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Bonuses
{
	public class TreeofLife : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 42;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Lime;
			item.createTile = ModContent.TileType<TreeofLife>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tree of Life");
			Tooltip.SetDefault("15% increased health restored by healing potions for nearby players");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "生命树");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在其附近的玩家增加 15% 生命药水的增益数值");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Дерево жизни");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает здоровье, восстанавливаемое зельями лечения, на 15% для ближайших игроков");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RichMahogany, 10)
				.AddIngredient(ItemID.ChlorophyteBar, 3)
				.AddIngredient(ItemID.ClayPot)
				.AddIngredient(ItemID.LifeFruit, 3)
				.Register();
		}
	}
}