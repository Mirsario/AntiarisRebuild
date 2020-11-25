using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Buffs.Mounts
{
	public class EmeraldSlime : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Emerald Slime");
			Description.SetDefault("Even more BOOOIIINNNG!");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Изумрудный слизень");
			Description.AddTranslation((int)GameCulture.CultureName.Russian, "Ещё больше БДЫНЬ!");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<EmeraldSlime>(), player);
			player.buffTime[buffIndex] = 10;
			player.armorEffectDrawShadow = true;
			if (player.wet)
			{
				player.wetSlime = 30;
				if (player.velocity.Y > 2f)
				{
					player.velocity.Y = player.velocity.Y * 0.9f;
				}
				player.velocity.Y = player.velocity.Y - 1f;
				if (player.velocity.Y < -5f)
				{
					player.velocity.Y = -5f;
				}
				if (player.controlJump)
				{
					player.velocity.Y = -20f;
				}
			}
			Microsoft.Xna.Framework.Rectangle checkDamagePlayer = player.getRect();
			checkDamagePlayer.Offset(0, player.height - 1);
			checkDamagePlayer.Height = 2;
			checkDamagePlayer.Inflate(12, 6);
			for (int i = 0; i < 200; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.immune[player.whoAmI] == 0)
				{
					Microsoft.Xna.Framework.Rectangle checkDamageNPC = npc.getRect();
					if (checkDamagePlayer.Intersects(checkDamageNPC) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
					{
						var damage = 60f * player.meleeDamage;
						float knockBack = 5f;
						int direction = player.direction;
						if (player.velocity.X < 0f)
						{
							direction = -1;
						}
						if (player.velocity.X > 0f)
						{
							direction = 1;
						}
						if (player.whoAmI == Main.myPlayer)
						{
							npc.StrikeNPC((int)damage, knockBack, direction, false, false, false);
							if (Main.netMode != NetmodeID.SinglePlayer)
								NetMessage.SendData(MessageID.StrikeNPC, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, 1, knockBack, direction, (int)damage);
						}
						npc.immune[player.whoAmI] = 10;
						player.velocity.Y = -20f;
						player.immune = true;
						break;
					}
				}
			}
		}
	}
}
