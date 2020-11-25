using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class TrueGungnir : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 18;
			item.useTime = 18;
			item.shootSpeed = 5.6f;
			item.knockBack = 7.4f;
			item.width = 80;
			item.height = 80;
			item.damage = 71;
			item.scale = 1.1f;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<TrueGungnir>();
			item.rare = ItemRarityID.Yellow;
			item.value = Item.sellPrice(0, 12, 34, 30);
			item.noMelee = true;
			item.noUseGraphic = true;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Gungnir");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "真·永恒之枪");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Истинный Гунгнир");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Gungnir)
				.AddIngredient(ItemID.BrokenHeroSword)
				.AddTile(134)
				.Register();
		}
	}
}
