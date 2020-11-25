using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MarbleKing : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 52;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble King");
			Tooltip.SetDefault("'One of the pieces of pure magic. Never falter, no matter what.'\n25% increased magic damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大理石国王棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。无论发生什么事，都不要犹豫。”\n增加 25% 魔法伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мраморный слон");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Никогда не колебись, несмотря ни на что.'\nУвеличивает магический урон на 25%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MarbleBlock, 5)
				.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
