using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class TheClaymoreOfRedCrystal : ModItem
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
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6.2f;
			item.value = Item.sellPrice(0, 9, 25, 0);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<TheRedShard>();
			item.shootSpeed = 5.6f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Claymore of Red Crystal");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "红水晶之刃");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Клеймор красного кристалла");
			Tooltip.SetDefault("Shoots crystal blades\n<right> to control direction of the blades");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Стреляет кристальными клинками\n<right>, чтобы управлять их направлением");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "发射水晶之刃\n<right> 控制水晶之刃移动方向");
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Broadsword);
		}*/

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.altFunctionUse == 2)
				foreach (Projectile projectile in Main.projectile)
					if (Main.myPlayer == projectile.owner && projectile.active && projectile.type == item.shoot)
					{
						Vector2 mouse = Main.MouseWorld;
						Vector2 vector2_1 = mouse;
						float speed = 10f;
						Vector2 vector2_2 = vector2_1 - projectile.Center;
						float distance = (float)Math.Sqrt(vector2_2.X * (double)vector2_2.X + vector2_2.Y * (double)vector2_2.Y);
						vector2_2 *= speed / distance;
						projectile.velocity = vector2_2;
					}
			return player.altFunctionUse != 2;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.EnchantedSword, 1)
				.AddIngredient(null, "RedBigCrystal", 15)
				.AddIngredient(null, "RedCrystalPixieDust", 15)
				.AddTile(134)
				.Register();
		}
	}
}
