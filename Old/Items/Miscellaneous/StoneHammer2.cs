using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
	public class StoneHammer2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Hammer");
			Tooltip.SetDefault("Strong and sharp enough to break mirrors");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "入魔石锤");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "强大和锐利到足以摧毁魔镜");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Каменный молот");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Достаточно сильный и острый, чтобы разбивать зеркала");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 48;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 20;
			item.useAnimation = 25;
			item.useTime = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
		}
	}
}