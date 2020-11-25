using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Antiaris.Items.Tools.Axes
{
	public class HoneyedAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 33;
			item.melee = true;
			item.width = 44;
			item.height = 42;
			item.useTime = 15;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 19, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.axe = 20;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Axe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовый топор");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
			this.SetTag(ItemTags.BluntHit);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Antiaris:CopperAxe")
				.AddIngredient(null, "HoneyExtract", 6)
				.AddIngredient(ItemID.HoneyBlock, 20)
				.AddIngredient(ItemID.BottledHoney, 4)
				.AddTile(134)
				.Register();
		}
	}
}