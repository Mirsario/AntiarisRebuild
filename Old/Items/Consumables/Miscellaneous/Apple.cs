using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Miscellaneous
{
	public class Apple : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			item.maxStack = 99;
			item.rare = ItemRarityID.White;
			item.useAnimation = 25;
			item.useTime = 25;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
			item.buffType = 26;
			item.buffTime = 10800;
			item.value = Item.sellPrice(0, 0, 0, 10);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apple");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "苹果");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Яблоко");
		}
	}
}
