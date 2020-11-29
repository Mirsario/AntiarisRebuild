using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Content.Items.Materials
{
	public class HoneyExtract : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 30;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
			item.consumable = true;
			item.buffType = BuffID.Honey;
			item.buffTime = 900;
			item.useAnimation = 15;
			item.useTime = 15;
			item.UseSound = SoundID.Item2;
			item.useStyle = ItemUseStyleID.EatFood;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honey Extract");
			Tooltip.SetDefault("Can be consumed to gain increased life regeneration");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовый экстракт");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Можно съесть, чтобы повысить восстановление здоровья");
		}
	}
}
