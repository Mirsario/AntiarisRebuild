using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	public class MarbleKnight : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 40;
			item.rare = ItemRarityID.LightPurple;
			item.value = Item.buyPrice(0, 0, 40, 0);
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Knight");
			Tooltip.SetDefault("'One of the pieces of pure magic. Make your stand, and prove yourself.'\n10% increased magic damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "大理石骑士棋子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“一个纯粹的魔法的碎片。让你站起来，证明你自己。”\n增加 10% 魔力伤害");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Мраморный рыцарь");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Одна из трёх частей истинной магии. Стой смело и прояви себя.'\nУвеличивает магический урон на 10%");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.1f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MarbleBlock, 5)
				.AddIngredient(ItemID.HellstoneBar, 5)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(114)
				.Register();
		}
	}
}
