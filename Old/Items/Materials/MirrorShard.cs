using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Materials
{
	public class MirrorShard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 30;
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 999;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mirror Shard");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔镜碎片");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Осколок зеркала");
		}
	}
}
