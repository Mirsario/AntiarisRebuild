using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class RuneofTranquility : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rune of Tranquility");
			Tooltip.SetDefault("After taking damage from an enemy, grants 15% damage reduction for 5 seconds");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "安魂符文");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "当敌人对你造成伤害后，5秒内承受的伤害减少15%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Руна спокойствия");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "После получения урона снижает получаемый урон на 5% на 5 секунд");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.RuneofTranquility = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RuneStone", 7)
				.AddIngredient(null, "TranquilityElement", 10)
				.AddIngredient(ItemID.ShadowScale, 12)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "RuneStone", 7)
				.AddIngredient(null, "TranquilityElement", 10)
				.AddIngredient(ItemID.TissueSample, 12)
				.AddTile(16)
				.Register();
		}
	}
}
