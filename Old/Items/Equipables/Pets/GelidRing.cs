using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class GelidRing : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.rare = ItemRarityID.Yellow;
			item.width = 24;
			item.height = 30;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.shoot = ModContent.ProjectileType<Snowflake>();
			item.buffType = ModContent.BuffType<Snowflake>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelid Ring");
			Tooltip.SetDefault("Summons a pet snowflake");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "寒冰戒指");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个宠物雪花");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ледяное кольцо");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает ручную снежинку");
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