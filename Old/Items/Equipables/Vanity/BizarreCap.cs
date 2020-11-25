using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Equipables.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class BizarreCap : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = Item.buyPrice(0, 10, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bizarre Cap");
			Tooltip.SetDefault("'Good grief...'");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "怪异的帽子");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "“我的天哪...”");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Волшебная кепка");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "'Ну и ну...'");
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.yoraiz0rDarkness = true;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.bizzare = true;
		}

		public override void UpdateVanity(Player player, EquipType type)
		{
			player.yoraiz0rDarkness = true;
			AntiarisPlayer aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.bizzare = true;
		}

		public class BizarrePlayer : ModPlayer
		{
			private bool HasCap(Player player)
			{
				foreach (Item item in player.armor)
				{
					if (item.type == ModContent.ItemType<BizarreCap>())
						return true;
				}
				return false;
			}

			public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
			{
				if (HasCap(player))
					drawInfo.headArmorShader = 0;
			}

			public override void FrameEffects()
			{
				if (HasCap(player) && (player.dye[0].type == ItemID.PurpleDye || player.dye[0].type == ItemID.BrightPurpleDye || player.dye[0].type == ItemID.PurpleOozeDye))
				{
					player.head = mod.GetEquipSlot("PurpleCap", EquipType.Head);
				}
				if (HasCap(player) && (player.dye[0].type == ItemID.SilverDye || player.dye[0].type == ItemID.BrightSilverDye))
				{
					player.head = mod.GetEquipSlot("WhiteCap", EquipType.Head);
				}
				if (HasCap(player) && (player.dye[0].type == ItemID.BlackDye || player.dye[0].type == ItemID.ShadowDye))
				{
					player.head = mod.GetEquipSlot("BlackCap", EquipType.Head);
				}
			}
		}

		public class BlackCap : EquipTexture
		{
			public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
			{
				drawHair = true;
				drawAltHair = true;
			}
		}

		public class WhiteCap : EquipTexture
		{
			public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
			{
				drawHair = true;
				drawAltHair = true;
			}
		}

		public class PurpleCap : EquipTexture
		{
			public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
			{
				drawHair = true;
				drawAltHair = true;
			}
		}
	}
}
