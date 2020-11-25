using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools.Fishing
{
	public class GooFishingPole : ModItem
	{
		public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask");
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale);
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.GoldenFishingRod);
			item.fishingPole = 29;
			item.value = Item.sellPrice(0, 0, 16, 0);
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<GooFishingPole>();
			item.shootSpeed = 14f;
			item.width = 52;
			item.height = 46;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Fishing Pole");
			Tooltip.SetDefault("Has a chance to fish out a slimy crate");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "凝胶钓竿");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "有几率钓出粘液板条箱");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Удочка из слизи");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "С некоторым шансом вылавливает слизневый ящик");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LiquifiedGoo", 1)
				.AddIngredient(ItemID.WoodFishingPole, 1)
				.AddTile(16)
				.Register();
		}
	}
}