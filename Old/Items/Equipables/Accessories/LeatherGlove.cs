using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class LeatherGlove : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 40;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.accessory = true;
			item.defense = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Glove");
			Tooltip.SetDefault("8% increased melee speed");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "皮革手套");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 8% 近战攻速");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кожаная перчатка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает скорость ближнего боя на 8%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += 0.08f;
		}
	}
}
