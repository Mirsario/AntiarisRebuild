using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools.Pickaxes
{
	public class SteelShovel : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 2;
			item.melee = true;
			item.width = 50;
			item.height = 52;
			item.useTime = 16;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 60;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Shovel");
			Tooltip.SetDefault("Can dig only soils");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "铁铲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "只能挖掘沙土");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Стальная лопата");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Может копать только почвы");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
		}*/
	}
}