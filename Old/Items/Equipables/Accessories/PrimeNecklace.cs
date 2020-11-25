using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class PrimeNecklace : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 44;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 7, 0, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prime Necklace");
			Tooltip.SetDefault("Increases your max number of minions\n10% increased minion damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "首领项链");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、增加召唤物上限\n2、增加 10% 召唤物伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Прайм-ожерелье");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 10%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.1f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PygmyNecklace)
				.AddIngredient(ItemID.AvengerEmblem)
				.AddTile(114)
				.Register();
		}
	}
}
