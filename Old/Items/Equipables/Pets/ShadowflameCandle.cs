using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class ShadowflameCandle : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 34;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 64, 60);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item8;
			item.autoReuse = false;
			item.buffType = ModContent.BuffType<ShadowflameCandle>();
			item.shoot = ModContent.ProjectileType<ShadowflameCandle>();
			item.shootSpeed = 3.5f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Candle");
			Tooltip.SetDefault("Summons a shadowy candle to provide light");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火蜡烛");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个暗影火蜡烛");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Свеча теневого пламени");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает теневую свечу");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Candle)
				.AddIngredient(ItemID.SoulofNight, 12)
				.AddIngredient(null, "Shadowflame", 15)
				.AddTile(134)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(ItemID.PlatinumCandle)
				.AddIngredient(ItemID.SoulofNight, 12)
				.AddIngredient(null, "Shadowflame", 15)
				.AddTile(134)
				.Register();
		}
	}
}