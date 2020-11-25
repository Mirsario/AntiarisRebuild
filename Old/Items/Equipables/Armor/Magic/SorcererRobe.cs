using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
	[AutoloadEquip(EquipType.Body)]
	public class SorcererRobe : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 30;
			item.rare = ItemRarityID.Green;
			item.defense = 5;
			item.value = Item.sellPrice(0, 0, 18, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sorcerer's Robe");
			Tooltip.SetDefault("8% increased magic damage");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "巫师法袍");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "魔法伤害增加 8%");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Роба колдуна");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Увеличивает магический урон на 8%");
		}

		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
		{
			glowMask = AntiarisGlowMasks.SorcererRobe;
			glowMaskColor = Color.White;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.08f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "DiscipleRobe", 1)
				.AddIngredient(null, "WrathElement", 10)
				.AddIngredient(ItemID.ShadowScale, 15)
				.AddTile(16)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "DiscipleRobe", 1)
				.AddIngredient(null, "WrathElement", 10)
				.AddIngredient(ItemID.TissueSample, 15)
				.AddTile(16)
				.Register();
		}
	}
}
