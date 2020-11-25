﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Boomerangs
{
	public class MandibleBoomerang : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 24;
			item.height = 40;
			item.useTime = 20;
			item.shootSpeed = 12f;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<MandibleBoomerang>();
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mandible Boomerang");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮下颚回旋镖");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Челюстный бумеранг");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Boomerang);
		}*/

		public override bool CanUseItem(Player player)
		{
			const int WheelMax = 1;
			int Count = 0;
			foreach (Projectile projectile in Main.projectile)
				if (projectile.type == item.shoot && projectile.owner == item.owner && projectile.active)
				{
					Count++;
				}
			return (Count > WheelMax) ? false : true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.WoodenBoomerang, 1)
				.AddIngredient(ItemID.AntlionMandible, 6)
				.AddIngredient(ItemID.SandBlock, 5)
				.AddIngredient(null, "AntlionCarapace", 6)
				.AddTile(16)
				.Register();
		}
	}
}
