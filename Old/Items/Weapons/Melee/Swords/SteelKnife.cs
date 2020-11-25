using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class SteelKnife : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 9;
			item.melee = true;
			item.width = 34;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Steel Knife");
			Tooltip.SetDefault("Grants 5 defense when used");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "钢匕首");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Стальной нож");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Даёт 5 защиты при использовании");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/
	}
}
