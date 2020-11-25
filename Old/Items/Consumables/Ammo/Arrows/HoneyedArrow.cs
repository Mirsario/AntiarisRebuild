using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Arrows
{
	public class HoneyedArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 14;
			item.DamageType = DamageClass.Ranged;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 14;
			item.height = 32;
			item.shoot = ModContent.ProjectileType<HoneyedArrow>();
			item.shootSpeed = 3f;
			item.knockBack = 3.0f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.LightRed;
			item.ammo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Arrow");
			Tooltip.SetDefault("Has a chance to summon honey candy on hit\nIt restores health and increases regeneration upon pickup");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовая стрела");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Имеет шанс призвать медовую конфетку при попадании\nКонфетка восстанавливает здоровье и увеличивает его восстановление при поднятии");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "");
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient(ItemID.WoodenArrow, 150)
				.AddIngredient(null, "HoneyExtract")
				.AddTile(134)
				.Register();
		}
	}
}
