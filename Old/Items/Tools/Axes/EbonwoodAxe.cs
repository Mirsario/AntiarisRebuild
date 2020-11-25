using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Antiaris.Items.Tools.Axes
{
	public class EbonwoodAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 3;
			item.melee = true;
			item.width = 32;
			item.height = 28;
			item.useTime = 16;
			item.useAnimation = 28;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 0, 19);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.axe = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Axe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "乌木斧");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Топор из эбонитовой древесины");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
			this.SetTag(ItemTags.BluntHit);
			this.SetTag(ItemTags.Flammable);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Ebonwood, 9)
				.AddTile(18)
				.Register();
		}
	}
}