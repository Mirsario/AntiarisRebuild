using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Summoner
{
	[AutoloadEquip(EquipType.Body)]
	public class AntlionBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.rare = ItemRarityID.Orange;
			item.defense = 5;
			item.value = Item.sellPrice(0, 1, 10, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Breastplate");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "蚁狮胸甲");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Нагрудник муравиьного льва");
			Tooltip.SetDefault("6% increased minion damage\nIncreases your max number of minions");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、增加 6% 召唤伤害\n2、增加召唤物最大上限");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает урон миньонов на 6%\nУвеличивает максимальное количество миньонов");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.06f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.AntlionMandible, 3)
				.AddIngredient(ItemID.BeeBreastplate)
				.AddIngredient(null, "AntlionCarapace", 16)
				.AddTile(16)
				.Register();
		}
	}
}
