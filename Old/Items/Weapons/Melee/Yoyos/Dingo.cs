using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class Dingo : ModItem
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
			item.shoot = ModContent.ProjectileType<Dingo>();
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 1f;
			item.damage = 32;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.useStyle = ItemUseStyleID.HoldingOut;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dingo");
			Tooltip.SetDefault("Sprays honey in different directions after each fifth enemy hit");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Динго");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Распыляет мёд в разных направлениях при каждом пятом ударе");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.JungleYoyo)
				.AddIngredient(null, "HoneyExtract", 10)
				.AddIngredient(ItemID.HoneyBlock, 30)
				.AddIngredient(ItemID.BottledHoney, 8)
				.AddTile(134)
				.Register();
		}
	}
}
