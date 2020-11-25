using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class CalmnessRing : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.rare = ItemRarityID.Blue;
			item.width = 24;
			item.height = 30;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.shoot = ModContent.ProjectileType<CalmnessSpirit>();
			item.buffType = ModContent.BuffType<CalmnessSpirit>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Calmness Ring");
			Tooltip.SetDefault("Summons a friendly calmness spirit");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宁静之戒");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个友好的宁静灵魂");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кольцо спокойствия");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает ручного духа спокойствия");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}