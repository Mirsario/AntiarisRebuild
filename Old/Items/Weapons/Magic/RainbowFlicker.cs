using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class RainbowFlicker : ModItem
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
			item.damage = 38;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item72;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RainbowShot1>();
			item.shootSpeed = 15f;
			item.mana = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Flicker");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "闪耀虹彩");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Радужная вспышка");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.MagicWeapon);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector = Main.MouseWorld;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("RainbowShot" + (int)(Main.rand.Next(6) + 1)), damage, knockBack, player.whoAmI, vector.X, vector.Y);
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SpellTome, 1)
				.AddIngredient(ItemID.CrystalShard, 12)
				.AddIngredient(ItemID.SoulofLight, 8)
				.AddIngredient(ItemID.Ruby, 2)
				.AddIngredient(ItemID.Amber, 2)
				.AddIngredient(ItemID.Topaz, 2)
				.AddIngredient(ItemID.Emerald, 2)
				.AddIngredient(ItemID.Sapphire, 2)
				.AddIngredient(ItemID.Amethyst, 2)
				.AddTile(16)
				.Register();
		}
	}
}
