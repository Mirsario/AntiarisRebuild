using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace Antiaris.Content.Items.Weapons.Ranged.Guns
{
	public class AcornChopper : ModItem
	{
		public override void SetDefaults()
		{
			item.DamageType = DamageClass.Ranged;
			item.damage = 16;
			item.width = 44;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.Shoot;
			item.noMelee = true;
			item.knockBack = 2;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Acorn>();
			item.shootSpeed = 6f;
			item.value = Item.sellPrice(0, 0, 0, 75);
			item.useAmmo = ItemID.Acorn;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Chopper");
			Tooltip.SetDefault("Uses acorn as ammo");

			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "使用橡子作为弹药");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "橡子粉碎机");

			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Измельчитель желудей");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Использует желуди в качестве патронов");
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 newPos = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;

			if (Collision.CanHit(position, 0, 0, position + newPos, 0, 0))
			{
				position += newPos;
			}

			speedX *= 0.7f + (Main.rand.Next(10) / 20f);
			speedY *= 0.7f + (Main.rand.Next(10) / 20f);

			speedX += (Main.rand.Next(-1, 2) / 10);
			speedY += (Main.rand.Next(-1, 2) / 10);

			return true;
		}

		/*public override bool CanUseItem(Player player)
		{
			return Util.ConsumeAmmo(ref player, ItemID.Acorn);
		}*/

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 0);
		}

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			if (!Main.playerInventory)
			{
				int index = 20;
				for (int j = 0; j < 10; ++j)
				{
					float scale_ = Main.hotbarScale[j];
					int position_ = (int)(20 + 22 * (1 - (double)scale_));
					Item item = Main.LocalPlayer.inventory[j];

					if (item.stack > 0 && item.type == ModContent.ItemType<AcornChopper>())
					{
						var pos = new Vector2(index, position_);
						int text = 0;

						for (int m = 0; m < 50; m++)
						{
							Item item2 = Main.LocalPlayer.inventory[m];

							if (item2.type == ItemID.Acorn)
							{
								if (item2.stack > 0)
								{
									text += item2.stack;
								}
								else
								{
									text = 0;
								}
							}
						}

						ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, "" + text, pos + new Vector2(10f * scale_, 32f * scale_), Color.White, 0f, default, new Vector2(scale_ *= 0.8f), -1f, 0.8f);
					}

					index += (int)(TextureAssets.InventoryBack.Value.Width * (double)Main.hotbarScale[j]) + 4;
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.StoneBlock, 15)
				.AddIngredient(ItemID.Wood, 12)
				.AddIngredient(ItemID.Acorn, 6)
				.AddIngredient<Materials.NatureEssence>(11)
				.AddTile(16)
				.Register();
		}
	}
}
