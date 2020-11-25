using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class Radiance : ModItem
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
			item.damage = 61;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.5f;
			item.value = Item.sellPrice(0, 7, 0, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Radiance");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Сияние");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虚伪正义");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射神圣烈焰\n“那两颗宝石跟地狱小鬼的眼珠子似的！”");
			Tooltip.SetDefault("Fires a celestial flame");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Выстреливает небесным огоньком");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override bool UseItem(Player player)
		{
			if (player.Center.X > Main.mouseX + (double)Main.screenPosition.X)
				player.direction = -1;
			else
				player.direction = 1;
			int i = Projectile.NewProjectile(player.Center.X + -40 * player.direction + Main.rand.Next(-34, 21), player.Center.Y - Main.rand.Next(-25, 45), 0.0f, 0.0f, ModContent.ProjectileType<CelestialMagicCentral>(), (int)(item.damage * (double)player.meleeDamage), 7.5f, player.whoAmI, 0.0f, 0.0f);
			Main.projectile[i].penetrate = 2;
			return true;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57);
			if (Main.rand.Next(5) == 0)
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 73);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Excalibur, 1)
				.AddIngredient(ItemID.SoulofLight, 12)
				.AddIngredient(null, "WrathElement", 6)
				.AddIngredient(ItemID.CrystalShard, 20)
				.AddTile(134)
				.Register();
		}
	}
}
