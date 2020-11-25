using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
	[AutoloadEquip(EquipType.Body)]
	public class NecromancerRobe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.rare = ItemRarityID.Yellow;
			item.defense = 12;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necromancer Robe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "死灵法师法袍");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Роба некроманта");
			Tooltip.SetDefault("Increases your max amount of minions\n15% increased minion damage");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、增加召唤物最大上限\n2、增加 15% 召唤物伤害");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает максимальное количество миньонов\nУвеличивает урон миньонов на 15%");
		}

		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 2;
			player.minionDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "NecroCloth", 18)
				.AddIngredient(ItemID.Bone, 10)
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddTile(134)
				.Register();
		}
	}
}
