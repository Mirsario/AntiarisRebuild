using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class SealedSoulofShadows : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 44;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sealed Soul of Shadows");
			Tooltip.SetDefault("Dealing critical damage restores life");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "密封的暗魂");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "造成致命一击时将恢复生命");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Запечатанная душа теней");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Нанесение критического урона восстанавливает здоровье");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.critHeal = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "ShadowChargedCrystal", 15)
				.AddIngredient(ItemID.SoulofNight, 20)
				.AddIngredient(ItemID.ShadowScale, 8)
				.AddIngredient(null, "BloodDroplet", 25)
				.AddIngredient(null, "VampiricEssence", 5)
				.AddIngredient(null, "WrathElement", 6)
				.AddTile(26)
				.Register();
		}
	}
}