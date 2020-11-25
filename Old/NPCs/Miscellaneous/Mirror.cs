using Antiaris.Items.Miscellaneous;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Miscellaneous
{
	public class Mirror : ModNPC
	{
		internal static readonly int[] StoneHammer = {
			ModContent.ItemType<StoneHammer1>(),
			ModContent.ItemType<StoneHammer2>()
		};

		public override void SetDefaults()
		{
			npc.friendly = true;
			npc.townNPC = true;
			npc.dontTakeDamage = true;
			npc.noGravity = true;
			npc.width = 48;
			npc.height = 54;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.aiStyle = 0;
			npc.knockBackResist = 0f;
			npc.rarity = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mirror");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "魔镜");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Зеркало");
			NPCID.Sets.TownCritter[npc.type] = true;
		}

		public override bool UsesPartyHat()
		{
			return false;
		}

		public override void AI()
		{
			npc.wet = false;
			npc.lavaWet = false;
			npc.honeyWet = false;
			npc.velocity.X = npc.velocity.Y = 0f;
			npc.dontTakeDamage = true;
			Player player = Main.LocalPlayer;
			if (player.active && !player.dead && Vector2.Distance(npc.Center, player.Center) <= 1000.0)
			{
				player.GetModPlayer<AntiarisPlayer>(mod).mirrorZone = true;
				player.AddBuff(ModContent.BuffType<CursedBlocks>(), 60);
			}
			if (WorldGen.crimson)
			{
				Main.npcTexture[npc.type] = ModContent.GetTexture("Antiaris/NPCs/Miscellaneous/Mirror2");
			}
			else
			{
				Main.npcTexture[npc.type] = ModContent.GetTexture("Antiaris/NPCs/Miscellaneous/Mirror");
			}
			npc.immune[255] = 30;
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				npc.homeless = false;
				npc.homeTileX = -1;
				npc.homeTileY = -1;
				npc.netUpdate = true;
			}

			if (player.inventory[player.selectedItem].type == ModContent.ItemType<StoneHammer1>() || player.inventory[player.selectedItem].type == ModContent.ItemType<StoneHammer2>())
			{
				if (player.itemAnimation > 0)
				{
					var FirstRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 34, 34);
					FirstRectangle.Width = (int)(FirstRectangle.Width * player.inventory[player.selectedItem].scale);
					FirstRectangle.Height = (int)(FirstRectangle.Height * player.inventory[player.selectedItem].scale);
					if (player.direction == -1)
					{
						FirstRectangle.X -= FirstRectangle.Width;
					}
					if (player.gravDir == 1f)
					{
						FirstRectangle.Y -= FirstRectangle.Height;
					}
					if (player.itemAnimation < player.itemAnimationMax * 0.333)
					{
						if (player.direction == -1)
						{
							FirstRectangle.X -= (int)(FirstRectangle.Width * 1.4 - FirstRectangle.Width);
						}
						FirstRectangle.Width = (int)(FirstRectangle.Width * 1.4);
						FirstRectangle.Y += (int)(FirstRectangle.Height * 0.5 * player.gravDir);
						FirstRectangle.Height = (int)(FirstRectangle.Height * 1.1);
					}
					else if (player.itemAnimation >= player.itemAnimationMax * 0.666)
					{
						if (player.direction == 1)
						{
							FirstRectangle.X -= (int)(FirstRectangle.Width * 1.2);
						}
						FirstRectangle.Width *= 2;
						FirstRectangle.Y -= (int)((FirstRectangle.Height * 1.4 - FirstRectangle.Height) * player.gravDir);
						FirstRectangle.Height = (int)(FirstRectangle.Height * 1.4);
					}
					Rectangle SecondRectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
					if (FirstRectangle.Intersects(SecondRectangle) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
					{
						if (Main.netMode == NetmodeID.SinglePlayer)
							npc.Transform(ModContent.NPCType<BrokenMirror>());
						else
						{
							ModPacket packet = mod.GetPacket();
							packet.Write((byte)1);
							packet.Write(npc.whoAmI);
							packet.Send();
						}
						SoundEngine.PlaySound(13, (int)npc.position.X, (int)npc.position.Y, 0);
						Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore1"), 1f);
						Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore1"), 1f);
						Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore2"), 1f);
						Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore3"), 1f);
						Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore3"), 1f);
						player.inventory[player.selectedItem].stack -= 1;
						if (Main.netMode != NetmodeID.MultiplayerClient)
							NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
						return;
					}
				}
			}
		}

		public override string GetChat()
		{
			string Mirror1 = Language.GetTextValue("Mods.Antiaris.Mirror1");
			return Mirror1;
		}
	}

	public enum Transform : byte
	{
		brokenMirror
	}
}

