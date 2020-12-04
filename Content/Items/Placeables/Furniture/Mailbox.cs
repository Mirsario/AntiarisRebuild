using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Placeables.Furniture
{
	public class Mailbox : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.Swing;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = Mod.Find<ModTile>(nameof(Tiles.Furniture.Mailbox)).Type;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mailbox");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "信箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Почтовый ящик");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 14)
				.AddTile(106)
				.Register();
		}
	}
}
