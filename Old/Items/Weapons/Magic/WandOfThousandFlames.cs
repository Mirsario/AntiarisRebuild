using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class WandOfThousandFlames : ModItem
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
			item.damage = 36;
			item.magic = true;
			item.mana = 11;
			item.width = 46;
			item.height = 46;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.value = Item.sellPrice(0, 2, 60, 0);
			item.knockBack = 3.4f;
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<IchorSphere>();
			item.shootSpeed = 7.4f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of Thousand Flames");
			Tooltip.SetDefault("Creates multiple flames which wither your enemy away");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "千焰之杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤多个烈焰让你的敌人凋零");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох тысячи огней");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Создает несколько огней, которые ослабевают Вашего врага");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.UnholyDamage);
		}*/

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 46.0f;
			for (int k = 0; k < Main.rand.Next(2, 4); k++)
			{
				float speedXN = speedX + Main.rand.Next(-10, 11) * 0.1f;
				float speedYN = speedY + Main.rand.Next(-10, 11) * 0.1f;
				Projectile.NewProjectile(position.X, position.Y, speedXN, speedYN, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Ichor, 20)
				.AddIngredient(ItemID.SoulofNight, 14)
				.AddIngredient(ItemID.AdamantiteBar, 8)
				.AddTile(134)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "WandCore")
				.AddIngredient(ItemID.Ichor, 20)
				.AddIngredient(ItemID.SoulofNight, 14)
				.AddIngredient(ItemID.TitaniumBar, 8)
				.AddTile(134)
				.Register();
		}
	}
}
