using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class AdventurerSign : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 36;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adventurer's Sign");
			Tooltip.SetDefault("Pressing the 'Special Ability' key will teleport you to the Nurse\n[c/C35377:Only one adventurer item can be worn]");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "冒险家十字");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "点击“特殊能力”键将你传送到护士的所在地\n[c/FFB640:【如何设置“特殊能力”键】]\n请在游戏开始界面寻找“设置-控件-快捷键绑定”\n找到Mod Controls选项\n找到“Antiaris:Special Ability”并修改按键，默认按键为“L”\n[c/C35377:“特殊能力”类型饰品只能佩戴一件]");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Знак путешественника");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Нажатие на кнопку 'Специальная способность' телепортирует Вас к Медсестре\n[c/C35377:Можно носить только один предмет путешественника]");
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
			if (!player.buffType.Contains(ModContent.BuffType<Recharge>()))
			{
				if (AntiarisMod.adventurerKey.JustPressed)
				{
					for (int i = 0; i < Main.npc.Length; i++)
					{
						NPC npc = Main.npc[i];
						if (npc.type == NPCID.Nurse)
						{
							if (npc.active)
							{
								Microsoft.Xna.Framework.Vector2 teleport = npc.position;
								player.Teleport(teleport, -69);
								player.Center = teleport;
								AntiarisHelper.CreateDust(player, 64, 30);
								SoundEngine.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/AdventurerItem"), player.position);
								for (int l = 3; l < 8 + player.extraAccessorySlots; l++)
								{
									if (player.armor[l].type == ModContent.ItemType<CelestialManual>())
									{
										int newLife = Main.rand.Next(35, 55);
										player.statLife += newLife;
										player.HealEffect(newLife);
									}
								}
								player.AddBuff(ModContent.BuffType<Recharge>(), 900);
								NetMessage.SendData(65, -1, -1, null, 0, player.whoAmI, teleport.X, teleport.Y, 1, 0, 0);
							}
						}
					}
				}
			}
		}
	}
}
