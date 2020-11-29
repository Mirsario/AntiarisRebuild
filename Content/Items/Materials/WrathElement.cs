using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Content.Items.Materials
{
	public class WrathElement : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 32;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.rare = ItemRarityID.Orange;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrath Element");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "狂怒元素");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Элемент ярости");
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void PostUpdate()
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
			Vector2 targetPos = player.Center;
			int speed = 4;
			float speedFactor = 0.7f;
			var itemCenter = new Vector2(item.position.X + item.width * 0.5f, item.position.Y + item.height * 0.5f);
			float posX = targetPos.X - itemCenter.X;
			float posY = targetPos.Y - itemCenter.Y;
			float distance = (float)Math.Sqrt(posX * posX + posY * posY);

			for (int i = 0; i < 50; i++)
			{
				if (player.inventory[i].type != ItemID.None)
				{
					continue;
				}

				if (distance <= 75f || Vector2.Distance(targetPos, itemCenter) > 450.0)
				{
					continue;
				}

				distance = speed / distance;
				posX *= distance;
				posY *= distance;

				if (item.velocity.X < posX)
				{
					item.velocity.X = item.velocity.X + speedFactor;

					if (item.velocity.X < 0f && posX > 0f)
					{
						item.velocity.X = item.velocity.X + speedFactor;
					}
				}
				else if (item.velocity.X > posX)
				{
					item.velocity.X = item.velocity.X - speedFactor;

					if (item.velocity.X > 0f && posX < 0f)
					{
						item.velocity.X = item.velocity.X - speedFactor;
					}
				}

				if (item.velocity.Y < posY)
				{
					item.velocity.Y = item.velocity.Y + speedFactor;

					if (item.velocity.Y < 0f && posY > 0f)
					{
						item.velocity.Y = item.velocity.Y + speedFactor;
					}
				}
				else if (item.velocity.Y > posY)
				{
					item.velocity.Y = item.velocity.Y - speedFactor;

					if (item.velocity.Y > 0f && posY < 0f)
					{
						item.velocity.Y = item.velocity.Y - speedFactor;
					}
				}
			}
		}
	}
}
