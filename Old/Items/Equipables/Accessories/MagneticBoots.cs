using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class MagneticBoots : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 32;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(0, 0, 85, 0);
			item.accessory = true;
			item.defense = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magnetic Boots");
			Tooltip.SetDefault("Allows to fall faster\nHolding Down button increases fall speed\nNegates fall damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "磁力之靴");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、让你拥有更快的自身坠落速度，按<下>键增加自身坠落速度\n2、免疫坠落伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Магнетические ботинки");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Позволяют падать быстрее\nЗажатие <down> увеличивает скорость падения\nУстраняет урон от падения");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noFallDmg = true;
			if (player.controlDown)
			{
				player.maxFallSpeed *= 5f;
			}
			else
			{
				player.maxFallSpeed *= 1.5f;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LeatherBoots")
				.AddIngredient(null, "TranquilityElement", 8)
				.AddIngredient(ItemID.LuckyHorseshoe)
				.AddIngredient(ItemID.SilverBar, 12)
				.AddTile(114)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "LeatherBoots")
				.AddIngredient(null, "TranquilityElement", 8)
				.AddIngredient(ItemID.LuckyHorseshoe)
				.AddIngredient(ItemID.TungstenBar, 12)
				.AddTile(114)
				.Register();
		}
	}
}