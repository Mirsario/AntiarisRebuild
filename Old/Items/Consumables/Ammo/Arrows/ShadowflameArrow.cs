using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
	public class ShadowflameArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 17;
			item.DamageType = DamageClass.Ranged;
			item.width = 14;
			item.height = 32;
			item.knockBack = 4;
			item.rare = ItemRarityID.Pink;
			item.maxStack = 999;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<ShadowflameArrow>();
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowflame Arrow");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火箭");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Стрела теневого пламени");
		}

		public override void AddRecipes()
		{
			CreateRecipe(44)
				.AddIngredient(ItemID.WoodenArrow, 44)
				.AddIngredient(null, "Shadowflame")
				.AddTile(134)
				.Register();
		}
	}
}
