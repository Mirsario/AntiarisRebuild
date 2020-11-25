using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class HandheldDevice : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 38;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.rare = ItemRarityID.Yellow;
			item.autoReuse = true;
			item.value = Item.buyPrice(0, 50, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Handheld Device");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Портативный девайс");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "");
		}

		public override bool UseItem(Player player)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.handheldDevice = !aPlayer.handheldDevice;
			return true;
		}
	}
}
