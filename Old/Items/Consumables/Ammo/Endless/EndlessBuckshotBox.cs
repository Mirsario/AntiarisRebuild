using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Consumables.Ammo.Endless
{
	public class EndlessBuckshotBox : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 4;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 1;
			item.consumable = false;
			item.height = 14;
			item.width = 14;
			item.shootSpeed = 5f;
			item.knockBack = 1.4f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Green;
			item.ammo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Endless Buckshot Box");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Бесконечная коробка картечи");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Buckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "Buckshot", 3996)
				.AddTile(125)
				.Register();
		}
	}
}
