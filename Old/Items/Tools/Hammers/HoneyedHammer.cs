using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Antiaris.Items.Tools.Hammers
{
	public class HoneyedHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 27;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 7;
			item.value = Item.sellPrice(0, 0, 19, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.hammer = 85;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Hammer");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовый молот");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
			this.SetTag(ItemTags.BluntHit);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Antiaris:CopperHammer")
				.AddIngredient(null, "HoneyExtract", 6)
				.AddIngredient(ItemID.HoneyBlock, 20)
				.AddIngredient(ItemID.BottledHoney, 4)
				.AddTile(134)
				.Register();
		}
	}
}