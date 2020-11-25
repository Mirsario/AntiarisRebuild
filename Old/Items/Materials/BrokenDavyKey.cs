using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class BrokenDavyKey : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Green;
			item.maxStack = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Davy's Key");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сломанный ключ Дэйви");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "");
		}
	}
}