using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MellifiedSkull : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.rare = ItemRarityID.Green;
			item.value = Item.buyPrice(0, 0, 65, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mellified Skull");
			Tooltip.SetDefault("Getting hit increases life regeneration for 5 seconds");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Расплавленный череп");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Получение урона повышает восстановление здоровья на 5 секунд");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.mellifiedSkull = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ObsidianSkull)
				.AddIngredient(ItemID.BottledHoney, 12)
				.AddIngredient(ItemID.HoneyBlock, 15)
				.AddTile(16)
				.Register();
		}
	}
}
