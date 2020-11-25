using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class TranquilityElement : ModItem
	{
		private int timer = 0;

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 20;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Orange;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tranquility Element");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "宁静元素");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Элемент спокойствия");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void PostUpdate()
		{
			++timer;

			if (timer % 155 == 0)
			{
				Player owner = null;

				if (item.playerIndexTheItemIsReservedFor != -1)
				{
					owner = Main.player[item.playerIndexTheItemIsReservedFor];
				}
				else if (item.playerIndexTheItemIsReservedFor == 255)
				{
					owner = Main.LocalPlayer;
				}

				Player player = owner;
				var startPos = new Vector2(item.position.X + (item.width * 0.5f), item.position.Y + (item.height / 2));
				float rot = (float)Math.Atan2(startPos.Y - (player.position.Y + (player.height * 0.5f)), startPos.X - (player.position.X + (player.width * 0.5f)));

				item.velocity.X = (float)(Math.Cos(rot) * 5) * -1;
				item.velocity.Y = (float)(Math.Sin(rot) * 5) * -1;
			}

			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(item.position, item.width, item.height, 211, item.velocity.X * 0.5f, item.velocity.Y * 0.5f, 150, default, 1.2f);
			}
		}
	}
}
