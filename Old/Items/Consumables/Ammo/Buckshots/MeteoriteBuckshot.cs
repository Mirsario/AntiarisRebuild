﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Ammo.Buckshots
{
	public class MeteoriteBuckshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 8;
			item.width = 14;
			item.maxStack = 999;
			item.height = 14;
			item.rare = ItemRarityID.Blue;
			item.DamageType = DamageClass.Ranged;
			item.consumable = true;
			item.knockBack = 2f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.ammo = ModContent.ItemType<Buckshot>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Buckshot");
			Tooltip.SetDefault("Used as ammo for blunderbusses");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "陨铁火铳弹");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "用于火铳");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Метеоритовая картечь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Используется как патроны для мушкетонов");
		}

		public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<MeteoriteBuckshot>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(50)
				.AddIngredient(null, "Buckshot", 50)
				.AddIngredient(ItemID.MeteoriteBar, 1)
				.AddTile(16)
				.Register();
		}
	}
}
