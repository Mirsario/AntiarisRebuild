using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(new EquipType[] { EquipType.Balloon })]
	public class BundleofHorseshoeBalloons : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 38;
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
			item.value = Item.sellPrice(0, 6, 25, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bundle of Horseshoe Balloons");
			Tooltip.SetDefault("Allows the holder to quadruple jump\nIncreases jump height and negates fall damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "马蹄铁气球束");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、允许持有者四连跳\n2、增加跳跃高度\n3、免疫坠落伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Связка подкованных шаров");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Дает четырехкратный прыжок\nУвеличивает высоту прыжка и игнорирует урон от падения");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.doubleJumpCloud = true;
			player.doubleJumpSandstorm = true;
			player.doubleJumpBlizzard = true;
			player.jumpBoost = true;
			player.noFallDmg = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BundleofBalloons)
				.AddIngredient(ItemID.LuckyHorseshoe)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
