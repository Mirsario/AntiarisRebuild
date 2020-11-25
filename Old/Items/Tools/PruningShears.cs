using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools
{
	public class PruningShears : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 3;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 1;
			item.value = Item.sellPrice(0, 0, 4, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pruning Shears");
			Tooltip.SetDefault("Can cut vines");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "修枝剪");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "可以把藤蔓剪下来");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Секатор");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Может резать лианы");
		}
	}
}
