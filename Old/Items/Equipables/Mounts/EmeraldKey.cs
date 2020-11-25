using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Mounts
{
	public class EmeraldKey : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 0, 15, 0);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item81;
			item.noMelee = true;
			item.mountType = ModContent.MountType<EmeraldSlime>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Key");
			Tooltip.SetDefault("Summons a rideable Emerald Slime mount");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "翡绿之匙");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤翡绿史莱姆坐骑");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Изумрудный ключ");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает наездного изумрудного слизня");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LiquifiedGoo", 3)
				.AddIngredient(ItemID.GoldenKey, 1)
				.AddTile(16)
				.Register();
		}
	}
}
