using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
	[AutoloadEquip(EquipType.Head)]
	public class EnchantedHelmet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Orange;
			item.defense = 5;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Helmet");
			Tooltip.SetDefault("5% increased critical strike chance");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔石头盔");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 5% 致命一击概率");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зачарованный шлем");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает шанс критического удара на 5%");
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 5;
			player.rangedCrit += 5;
			player.magicCrit += 5;
			player.meleeCrit += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<EnchantedBreastplate>() && legs.type == ModContent.ItemType<EnchantedGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.manaCost -= 0.17f;
			player.statManaMax2 += 20;
			string EnchantedSetBonus = Language.GetTextValue("Mods.Antiaris.EnchantedSetBonus");
			player.setBonus = EnchantedSetBonus;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.enchantedSet = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
			player.armorEffectDrawShadowLokis = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 3)
				.AddIngredient(ItemID.GoldHelmet, 1)
				.AddTile(16)
				.Register();

			CreateRecipe()
				.AddIngredient(null, "EnchantedShard", 3)
				.AddIngredient(ItemID.PlatinumHelmet, 1)
				.AddTile(16)
				.Register();
		}
	}
}
