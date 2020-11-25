using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Bonuses
{
	public class DazzlingMirror : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 48;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.createTile = ModContent.TileType<DazzlingMirror>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dazzling Mirror");
			Tooltip.SetDefault("8% increased damage for nearby players");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "璀璨之镜");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "在其附近的玩家增加 8% 的伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сияющее зеркало");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает урон на 8% для ближайших игроков");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PearlstoneBlock, 20)
				.AddIngredient(ItemID.Glass, 6)
				.AddIngredient(null, "DazzlingHeart")
				.Register();
		}
	}
}