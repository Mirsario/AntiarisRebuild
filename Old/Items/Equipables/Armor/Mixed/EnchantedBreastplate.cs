using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
	[AutoloadEquip(EquipType.Body)]
	public class EnchantedBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.rare = ItemRarityID.Orange;
			item.defense = 6;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Breastplate");
			Tooltip.SetDefault("5% increased damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔石胸甲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 5% 伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зачарованный нагрудник");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает урон на 5%");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.05f;
			player.meleeDamage += 0.05f;
			player.thrownDamage += 0.05f;
			player.minionDamage += 0.05f;
			player.rangedDamage += 0.05f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 5)
				.AddIngredient(ItemID.GoldChainmail, 1)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "EnchantedShard", 5)
				.AddIngredient(ItemID.PlatinumChainmail, 1)
				.AddTile(16)
				.Register();
		}
	}
}
