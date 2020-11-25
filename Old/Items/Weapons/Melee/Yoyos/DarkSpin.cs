using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class DarkSpin : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<DarkSpin>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 1f;
			item.damage = 40;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.useStyle = ItemUseStyleID.HoldingOut;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Spin");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗旋");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Тёмное вращение");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodYoyo)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddIngredient(null, "Shadowflame", 15)
				.AddTile(134)
				.Register();
		}
	}
}
