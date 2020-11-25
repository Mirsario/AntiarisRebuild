using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Miscellaneous
{
	public class OrcishAxe : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Blue;
			item.axe = 13;
			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orcish Axe");
			Tooltip.SetDefault("<right> to mark an enemy as a prey\nPrey takes 50% more damage when under 10% of health\nPrey is marked on the map\nIncreases movement speed if close to the prey\nAn enemy is no longer prey if you don't hold the axe");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "兽人之斧");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、<right> 将敌人标记为猎物\n2、当生命值低于10%时，猎物会额外承受50%的伤害\n3、猎物将在地图上标记\n4、如果靠近猎物则增加移动速度\n5、如果你不手持“兽人之斧”时，猎物的标记则消失");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Оркский топор");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "<right>, чтобы отметить цель, как добычу\nДобыча получает на 50% больше урона, если у неё меньше 10% здоровья\nДобыча отмечается на карте\nСкорость передвижения увеличена, если рядом с добычей\nВраг перестает быть добычей, если вы не держите топор");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.axe = 0;
				item.damage = 0;
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useAnimation = 10;
				item.useTime = 10;
				item.autoReuse = false;

				CreateMark();
			}
			else
			{
				item.axe = 13;
				item.damage = 16;
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useAnimation = 30;
				item.useTime = 30;
				item.autoReuse = true;
			}
			return base.CanUseItem(player);
		}

		/*public void OverhaulInit()
		{
			this.SetTag(ItemTags.Tool);
		}*/

		NPC currentNPC = null;
		private void CreateMark()
		{
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC target = Main.npc[i];
				if (target.Hitbox.Contains(Main.MouseWorld.ToPoint()) && !target.friendly)
				{
					currentNPC = target;
					break;
				}
				if (currentNPC != null && currentNPC == target)
					currentNPC.AddBuff(ModContent.BuffType<Prey>(), 60);
				for (int j = 0; j < target.buffType.Length; j++)
				{
					int type = target.buffType[j];
					if (type == ModContent.BuffType<Prey>() && target != currentNPC)
						target.DelBuff(j);
				}
			}
		}
	}
}
