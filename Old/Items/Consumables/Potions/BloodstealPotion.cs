using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
	public class BloodstealPotion : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 34;
			item.useTurn = true;
			item.maxStack = 30;
			item.rare = ItemRarityID.LightPurple;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.buffType = ModContent.BuffType<Bloodsteal>();
			item.buffTime = 18000;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 2, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodsteal Potion");
			Tooltip.SetDefault("Attacks have a chance to restore health");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "嗜血药水");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "攻击时有概率恢复体力");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зелье воровства крови");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Атаки имеют шанс восстановить здоровье");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater, 1)
				.AddIngredient(null, "VampiricEssence", 1)
				.AddIngredient(null, "BloodDroplet", 2)
				.AddIngredient(ItemID.Deathweed, 2)
				.AddTile(13)
				.Register();
		}
	}
}
