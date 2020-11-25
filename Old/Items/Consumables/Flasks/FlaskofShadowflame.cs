using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Flasks
{
	public class FlaskofShadowflame : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 34;
			item.useTurn = true;
			item.maxStack = 30;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 16;
			item.useTime = 16;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.buffType = ModContent.BuffType<WeaponImbueShadowflame>();
			item.buffTime = 72000;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
			item.value = Item.sellPrice(0, 0, 6, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Shadowflame");
			Tooltip.SetDefault("Melee attacks inflict shadowflame on enemies");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "暗影火药水");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "近战攻击使敌人被暗影火点燃");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Флакон теневого пламени");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Ближние атаки накладывают на врагов теневое пламя");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(null, "Shadowflame", 2)
				.AddTile(243)
				.Register();
		}
	}
}
