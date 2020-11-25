using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools.Pickaxes
{
	public class HoneyedPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.melee = true;
			item.width = 34;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 23;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 19, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 120;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honeyed Pickaxe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Медовая кирка");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
			this.SetTag(ItemTags.BluntHit);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddRecipeGroup("Antiaris:CopperPickaxe")
				.AddIngredient(null, "HoneyExtract", 8)
				.AddIngredient(ItemID.HoneyBlock, 25)
				.AddIngredient(ItemID.BottledHoney, 5)
				.AddTile(134)
				.Register();
		}
	}
}