using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Thrown
{
	public class BoneDagger : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 24;
			item.thrown = true;
			item.width = 14;
			item.height = 26;
			item.noUseGraphic = true;
			item.useTime = 12;
			item.useAnimation = 12;
			item.shoot = ModContent.ProjectileType<BoneDagger>();
			item.shootSpeed = 6f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 0, 12);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Dagger");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Костяной клинок");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "骸骨飞刀");
		}

		public override void AddRecipes()
		{
			CreateRecipe(30)
				.AddIngredient(ItemID.Bone, 5)
				.AddTile(16)
				.Register();
		}
	}
}
