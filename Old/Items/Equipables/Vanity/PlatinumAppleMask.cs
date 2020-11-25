using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class PlatinumAppleMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.sellPrice(0, 1, 20, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Apple Mask");
			Tooltip.SetDefault("'It's supposed to be golden, but you don't have gold in your world.'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "铂金苹果面具");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "它应该是黄金的，但是你的世界并没有黄金");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Маска платинового яблока");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Она должна быть золотой, но у вас нет золота в мире.'");
		}
	}
}
