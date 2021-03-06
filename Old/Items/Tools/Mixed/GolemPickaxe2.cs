using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace Antiaris.Items.Tools.Mixed
{
	public class GolemPickaxe2 : ModItem
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
			item.damage = 21;
			item.melee = true;
			item.width = 54;
			item.height = 64;
			item.useTime = 18;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.pick = 105;
			item.axe = 30;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Pickaxe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔像镐斧");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Кирка голема");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
		}*/

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 8)
				.AddIngredient(null, "ShadowChargedCrystal", 10)
				.AddIngredient(ItemID.SoulofNight, 6)
				.AddIngredient(null, "WrathElement", 5)
				.AddTile(16)
				.Register();
		}
	}
}