using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Head)]
	public class SorcererHat : ModItem
	{
		private float timer;

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 20;
			item.rare = ItemRarityID.Green;
			item.defense = 4;
			item.value = Item.sellPrice(0, 0, 24, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer's Hat");
			Tooltip.SetDefault("Increases magic critical strike chance by 8%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "巫师法帽");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "魔法致命一击概率增加 8%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Шляпа колдуна");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает шанс магического критического удара на 8%");
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SorcererRobe>() && legs.type == ModContent.ItemType<SorcererPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.manaCost -= 0.1f;
			player.statManaMax2 += 30;
			string SorcererSetBonus = Language.GetTextValue("Mods.Antiaris.SorcererSetBonus");
			player.setBonus = SorcererSetBonus;
			++timer;
			if (Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) > 1.0f && !player.rocketFrame)
			{
				if (timer >= 120.0)
				{
					int manaAmount = Main.rand.Next(8, 14);
					player.statMana += manaAmount;
					player.ManaEffect(manaAmount);
					timer = 0.0f;
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "DiscipleHat", 1)
				.AddIngredient(null, "WrathElement", 5)
				.AddIngredient(ItemID.ShadowScale, 10)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "DiscipleHat", 1)
				.AddIngredient(null, "WrathElement", 5)
				.AddIngredient(ItemID.TissueSample, 10)
				.AddTile(16)
				.Register();
		}
	}
}
