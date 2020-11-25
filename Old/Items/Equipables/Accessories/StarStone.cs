using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class StarStone : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.value = Item.sellPrice(0, 4, 0, 15);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Stone");
			Tooltip.SetDefault("Mana stars restore more mana");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "星之石");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使魔力星可以回复更多魔力");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Звездный камень");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Звезды маны восстанавливают больше маны");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).starStone = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 15)
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddIngredient(null, "NatureEssence", 6)
				.AddIngredient(ItemID.ManaCrystal, 3)
				.AddTile(TileID.MythrilAnvil);
		}
	}
}
