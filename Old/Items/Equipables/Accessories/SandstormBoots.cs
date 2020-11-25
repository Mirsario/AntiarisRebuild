using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class SandstormBoots : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 36;
			item.rare = ItemRarityID.Orange;
			item.value = Item.sellPrice(0, 30, 0, 0);
			item.accessory = true;
			item.defense = 3;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandstorm Boots");
			Tooltip.SetDefault("Allows the wearer to perform a controllable jump\nGrants immunity to sandstorm wind\nIncreases defense when player stands on sand");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "沙暴之靴");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、允许玩家持续按 <跳跃>做长时间的可控跳跃\n2、免疫沙尘暴天气\n3、在沙漠环境下加强防御力");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Ботинки песчаной бури");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Позволяют носителю делать контролируемый прыжок\nДают иммунитет к ветру песчаной бури\nУвеличивают защиту, если игрок стоит на песке");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (!player.mount.Active)
			{
				player.buffImmune[194] = true;
				if (player.velocity.X != 0f && player.velocity.Y == 0f)
				{
					for (int m = 0; m < 3; m++)
					{
						int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y + ((player.gravDir == 1f) ? (player.height - 2) : -4)), player.width, 6, ModContent.DustType<Sandstorm>(), 0f, 0f, 100, default, 0.1f);
						Main.dust[dust].fadeIn = 1f;
						Main.dust[dust].noGravity = true;
						Main.dust[dust].velocity *= 0.2f;
						Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(player.ArmorSetDye(), player);
					}
				}
				if (!player.immune)
				{
					int tileX = (int)player.Center.X / 16;
					int tileY = (int)player.Center.Y / 16;
					if (Main.tile[tileX, tileY] != null && Main.tile[tileX, tileY + 10].type == TileID.Sand)
					{
						player.statDefense += 5;
					}
				}
				if (player.controlJump)
				{
					if (player.releaseJump || (player.autoJump && (player.velocity.Y == 0f || player.sliding)))
					{
						if (player.sliding || player.velocity.Y == 0f)
						{
							player.justJumped = true;
						}
						if (player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped))
						{
							SoundEngine.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
							player.velocity.Y = -Player.jumpSpeed * player.gravDir;
							player.jump = Player.jumpHeight * 6;
						}
					}
					if (((player.gravDir == 1f && player.velocity.Y < 0f) || (player.gravDir == -1f && player.velocity.Y > 0f)))
					{
						int height = player.height;
						if (player.gravDir == -1f)
						{
							height = -6;
						}
						float size = (player.jump / 75f + 1f) / 2f;
						for (int i = 0; i < 3; i++)
						{
							int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y + height / 2), player.width, 19, ModContent.DustType<Sandstorm>(), player.velocity.X * 0.3f, player.velocity.Y * 0.3f, 150, default, 1f * size);
							Main.dust[dust].velocity *= 0.5f * size;
							Main.dust[dust].fadeIn = 1.5f * size;
							int dust2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + height / 2), player.width, 32, ModContent.DustType<Sandstorm>(), player.velocity.X * 0.3f, player.velocity.Y * 0.3f, 150, default, 1f * size);
							Main.dust[dust2].velocity *= 0.5f * size;
							Main.dust[dust2].fadeIn = 1.5f * size;
						}
						player.sandStorm = true;
						if (player.miscCounter % 3 == 0)
						{
							int dust = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 18f, player.position.Y + height / 2), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(220, 223), size);
							Main.gore[dust].velocity = player.velocity * 0.3f * size;
							Main.gore[dust].alpha = 50;
						}
					}
				}
			}
		}
	}
}