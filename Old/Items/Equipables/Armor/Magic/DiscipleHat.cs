using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Head)]
	public class DiscipleHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 30;
			item.rare = ItemRarityID.Blue;
			item.defense = 2;
			item.value = Item.sellPrice(0, 0, 15, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Disciple's Hat");
			Tooltip.SetDefault("5% increased magic critical strike chance");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "门徒法帽");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "魔法致命一击概率增加 5%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шляпа ученика");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает шанс магического критического урона на 5%");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<DiscipleRobe>() && legs.type == ModContent.ItemType<DisciplePants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.statManaMax2 += 20;
			string DiscipleSetBonus = Language.GetTextValue("Mods.Antiaris.DiscipleSetBonus");
			player.setBonus = DiscipleSetBonus;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.discipleSet = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "RuneStone", 3)
				.AddIngredient(ItemID.Silk, 3)
				.AddTile(86)
				.Register();
		}
	}
}
