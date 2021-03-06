﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools.Pickaxes
{
	public class PalmWoodPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 3;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 0, 0, 21);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 30;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Pickaxe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "棕榈木镐");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кирка из пальмовой древесины");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
			this.SetTag(ItemTags.BluntHit);
			this.SetTag(ItemTags.Flammable);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PalmWood, 10)
				.AddTile(18)
				.Register();
		}
	}
}