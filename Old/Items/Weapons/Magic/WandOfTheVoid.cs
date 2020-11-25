using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class WandOfTheVoid : ModItem
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
			item.damage = 68;
			item.magic = true;
			item.mana = 12;
			item.width = 74;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4.5f;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item117;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<VoidBall>();
			item.shootSpeed = 6.4f;
			Item.staff[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wand of The Void");
			Tooltip.SetDefault("Summons pure void matter to destroy all your foes\n'Pulses with primal energy'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "虚空之杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤纯净虚空来摧毁你眼前的所有敌人\n“原始能量的脉冲”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох пустоты");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает пустоту материи для уничтожения всех врагов\n'Пульсирует первичной энергией'");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 60f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 44.0f;
			for (int k = 0; k < Main.rand.Next(3, 5); k++)
			{
				float speedXN = speedX + Main.rand.Next(-20, 21) * 0.1f;
				float speedYN = speedY + Main.rand.Next(-30, 31) * 0.1f;
				Projectile.NewProjectile(position.X, position.Y, speedXN, speedYN, type, (int)(damage * 0.8f), knockBack / 2, player.whoAmI);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "WandOfOrder")
				.AddIngredient(null, "WandOfFracture")
				.AddIngredient(null, "WandOfThousandCurses")
				.AddIngredient(ItemID.NebulaArcanum)
				.AddIngredient(ItemID.LunarBar, 10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();

			recipe = new ModRecipe(mod);
				.AddIngredient(null, "WandOfOrder")
				.AddIngredient(null, "WandOfFracture")
				.AddIngredient(null, "WandOfThousandFlames")
				.AddIngredient(ItemID.NebulaArcanum)
				.AddIngredient(ItemID.LunarBar, 10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
