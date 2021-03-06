using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class CosmicRayer : ModItem
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
			item.damage = 24;
			item.magic = true;
			item.width = 60;
			item.height = 32;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item12;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CosmicRay>();
			item.shootSpeed = 6f;
			item.mana = 6;
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Rayer");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宇宙辐射");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Космический лучевик");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SpaceGun)
				.AddIngredient(ItemID.MeteoriteBar, 12)
				.AddIngredient(ItemID.Ruby, 3)
				.AddIngredient(ItemID.Amethyst, 3)
				.AddIngredient(ItemID.FallenStar, 7)
				.AddTile(16)
				.Register();
		}
	}
}
