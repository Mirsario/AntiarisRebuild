using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Antiaris.Items.Consumables.Potions
{
	public class EnchantedLeafRoll : ModItem
	{
		byte Uses = 5;

		public override bool CloneNewInstances => true;

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.width = 22;
			item.height = 22;
			item.useStyle = ItemUseStyleID.Stabbing;
			item.useTime = 25;
			item.useAnimation = 25;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.rare = ItemRarityID.White;
			item.buffType = ModContent.BuffType<HallowedProtection>();
			item.buffTime = 3600;
			item.value = Item.sellPrice(0, 0, 5, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Leaf Roll");
			Tooltip.SetDefault("Restores 1 health each second for 40 seconds\nCan be used 5 times\nProvides damage reduction");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "附魔叶卷");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、40 秒内每秒可以恢复 1 点体力\n2、能够使用 5 次\n3、使使用者受到的伤害降低");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Рулон зачарованных листьев");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Восстанавливает 1 здоровье каждую секунду в течение 40 секунд\nМожно использовать 5 раз\nСнижает получаемый урон");
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<PatchedUp>(), 2400);
			Uses--;
			item.scale -= 0.087f;
			if (Uses <= 0)
			{
				item.SetDefaults(0);
			}
			return true;
		}

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> Tooltips)
		{
			string LeafRoll = Language.GetTextValue("Mods.Antiaris.LeafRoll");
			TooltipLine Tip = new TooltipLine(mod, "Antiaris:Tooltip", LeafRoll + Uses + "/5");
			Tooltips.Insert(4, Tip);
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(Uses);
		}

		public override void NetRecieve(BinaryReader reader)
		{
			Uses = reader.ReadByte();
		}

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{
					"U", Uses
				}
			};
		}

		public override void Load(TagCompound tag)
		{
			Uses = tag.GetByte("U");
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "EnchantedLeaf", 10)
				.AddIngredient(ItemID.VineRope, 4)
				.Register();
		}
	}
}
