using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class SealedSoulofBlood : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sealed Soul of Blood");
			Tooltip.SetDefault("Each fifth damage dealt restores life");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "密封的血魂");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "每第五次攻击将恢复生命");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Запечатанная душа крови");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Каждое пятое нанесение урона восстанавливает здоровье");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.hitHeal = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BloodyChargedCrystal", 15)
				.AddIngredient(ItemID.SoulofNight, 20)
				.AddIngredient(ItemID.TissueSample, 8)
				.AddIngredient(null, "BloodDroplet", 25)
				.AddIngredient(null, "VampiricEssence", 5)
				.AddIngredient(null, "WrathElement", 6)
				.AddTile(26)
				.Register();
		}
	}
}