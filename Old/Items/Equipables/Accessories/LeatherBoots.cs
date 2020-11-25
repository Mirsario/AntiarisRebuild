using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class LeatherBoots : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 38;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Boots");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "皮靴");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кожанные ботинки");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.OldShoe, 2)
				.AddIngredient(ItemID.Leather, 7)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}