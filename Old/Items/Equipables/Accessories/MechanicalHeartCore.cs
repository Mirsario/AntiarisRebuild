using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MechanicalHeartCore : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 60;
			item.value = Item.sellPrice(0, 4, 0, 15);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mechanical Heart Core");
			Tooltip.SetDefault("Life hearts restore more life");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "机械心脏核心");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "所有的生命之心将变得更强大");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ядро механического сердца");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Все сердца жизни становятся лучше");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).mechanicalHeart = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 15)
				.AddIngredient(ItemID.SoulofLight, 8)
				.AddIngredient(null, "NatureEssence", 6)
				.AddIngredient(ItemID.LifeCrystal, 3)
				.AddTile(134)
				.Register();
		}
	}
}
