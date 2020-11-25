using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class CelestialCross : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.rare = ItemRarityID.Pink;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.accessory = true;
			item.defense = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Cross");
			Tooltip.SetDefault("Pressing the 'Special Ability' key will teleport you to your cursor\nIncreased invincibility time after being struck\nLowers the cooldown for healing potions\n[c/C35377:Only one adventurer item can be worn]");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "神圣十字");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、点击“特殊能力”键将你传送到光标所在位置\n2、被击中后增加无敌时间\n3、减少生命恢复药水的冷却时间\n[c/FFB640:【如何设置“特殊能力”键】]\n请在游戏开始界面寻找“设置-控件-快捷键绑定”\n找到Mod Controls选项\n找到“Antiaris:Special Ability”并修改按键，默认按键为“L”\n[c/C35377:“特殊能力”类型饰品只能佩戴一件]");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Небесный крест");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Нажатие на кнопку 'Специальная способность' телепортирует Вас в ваш курсор\nУвеличивает время неуязвимости после получения урона\nСнижает кулдаун от зелий лечения\n[c/C35377:Можно носить только один предмет путешественника]");
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			for (int i = 0; i < player.armor.Length; i++)
			{
				AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
				if (aPlayer.aItems)
				{
					return false;
				}
			}
			return true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.aItems = true;
			player.pStone = true;
			player.longInvince = true;
			if (!player.buffType.Contains(ModContent.BuffType<Recharge>()))
			{
				if (AntiarisMod.adventurerKey.JustPressed)
				{
					var teleportPos = new Vector2();
					teleportPos.X = Main.mouseX + Main.screenPosition.X - player.width / 2;
					teleportPos.Y = player.gravDir != 1 ? (Main.screenPosition.Y + Main.screenHeight - Main.mouseY) : (Main.mouseY + Main.screenPosition.Y - player.height);
					if (teleportPos.X > 50 && teleportPos.X < (double)(Main.maxTilesX * 16 - 50) && (teleportPos.Y > 50 && teleportPos.Y < (double)(Main.maxTilesY * 16 - 55)))
					{
						int tileX = (int)(teleportPos.X / 16f);
						int tileY = (int)(teleportPos.Y / 16f);
						if (!Collision.SolidCollision(teleportPos, player.width, player.height))
						{
							AntiarisHelper.TeleportTo(player, teleportPos);
							AntiarisHelper.CreateDust(player, 64, 20);
							SoundEngine.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/AdventurerItem"), player.position);
							for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
							{
								int newLife = Main.rand.Next(35, 55);
								if (player.armor[l].type == ModContent.ItemType<CelestialManual>())
								{
									player.statLife += newLife;
									player.HealEffect(newLife);
								}
							}
							player.statLife += 15;
							NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, player.whoAmI, teleportPos.X, teleportPos.Y, 1, 0, 0);
							player.AddBuff(ModContent.BuffType<Recharge>(), 840);
						}
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PhilosophersStone)
				.AddIngredient(ItemID.CrossNecklace)
				.AddIngredient(ItemID.GreaterHealingPotion, 5)
				.AddIngredient(ModContent.ItemType<AdventurerSign>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
