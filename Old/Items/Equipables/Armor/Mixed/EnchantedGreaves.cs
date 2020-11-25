using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
	[AutoloadEquip(EquipType.Legs)]
	public class EnchantedGreaves : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.rare = ItemRarityID.Orange;
			item.defense = 5;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Greaves");
			Tooltip.SetDefault("5% increased movement speed");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔石护胫甲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 5% 移动速度");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зачарованные поножи");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает скорость передвижения");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 2)
				.AddIngredient(ItemID.GoldGreaves, 1)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "EnchantedShard", 2)
				.AddIngredient(ItemID.PlatinumGreaves, 1)
				.AddTile(16)
				.Register();
		}
	}
}
