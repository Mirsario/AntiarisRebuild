using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Antiaris.Items.Tools.Hammers
{
	public class GooHammer : ModItem
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
			item.damage = 19;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 0, 18, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.hammer = 60;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goo Hammer");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "凝胶锤");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Молот из слизи");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Hammer);
			this.SetTag(ItemTags.BluntHit);
			this.SetTag(ItemTags.Flammable);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LiquifiedGoo", 1)
				.AddRecipeGroup("Antiaris:WoodenHammer")
				.AddTile(16)
				.Register();
		}
	}
}