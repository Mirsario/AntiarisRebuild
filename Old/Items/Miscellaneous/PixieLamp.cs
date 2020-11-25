using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
	public class PixieLamp : ModItem
	{
		public override void HoldItem(Player player)
		{
			AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask2");
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask2"), rotation, scale);
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 34;
			item.maxStack = 1;
			item.rare = ItemRarityID.LightPurple;
			item.useAnimation = 26;
			item.useTime = 26;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.NPCHit5;
			item.useTurn = true;
			item.consumable = true;
			item.value = Item.sellPrice(0, 15, 0, 0);
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie Lamp");
			Tooltip.SetDefault("Creates a shining aura that attracts crystal pixies\nPixies will leave some dust if they come close to lamp");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "精灵灯");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "1、生成一个吸引水晶精灵的光环\n2、如果精灵靠近灯将掉落更多的精灵尘");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Лампа Пикси");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Создает ауру, которая привлекает кристальных пикси\nПикси оставят немного пыльцы, если подлетят близко к лампе");
		}

		public override bool UseItem(Player player)
		{
			foreach (NPC npc in Main.npc)
				if (npc.active && npc.type == ModContent.NPCType<PixieLamp>())
					return false;
			if (player.itemAnimation > 0 && player.itemTime == 0)
			{
				player.itemTime = (int)(item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<PixieLamp>(), 0, 0.0f, 0.0f, 0.0f, 0.0f, 255);
			}
			return base.UseItem(player);
		}
	}
}
