using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
	public class HellScythe : ModItem
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
			item.damage = 31;
			item.melee = true;
			item.width = 46;
			item.height = 54;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 2, 20, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<HellScythe>();
			item.shootSpeed = 8f;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hell Scythe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "地狱镰刀");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Адская коса");
		}
	}
}
