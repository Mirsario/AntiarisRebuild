using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
	[AutoloadEquip(EquipType.Body)]
	public class GooBreastplate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.rare = ItemRarityID.Green;
			item.defense = 5;
			item.value = Item.sellPrice(0, 0, 25, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Breastplate");
			Tooltip.SetDefault("5% increased critical strike chance");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "凝胶胸甲");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "增加 5% 致命一击概率");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Нагрудник из слизи");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает шанс критического удара на 5%");
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMask = drawPlayer.Male ? AntiarisGlowMasks.GooBreastplate : AntiarisGlowMasks.GooBreastplateF;
			glowMaskColor = Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 5;
			player.magicCrit += 5;
			player.rangedCrit += 5;
			player.thrownCrit += 5;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LiquifiedGoo", 1)
				.AddRecipeGroup("Antiaris:WoodBreastplate")
				.AddTile(16)
				.Register();
		}
	}
}
