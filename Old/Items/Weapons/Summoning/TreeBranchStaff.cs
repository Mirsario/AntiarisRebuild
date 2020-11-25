using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
	public class TreeBranchStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 12;
			item.summon = true;
			item.mana = 10;
			item.width = 54;
			item.height = 72;
			item.useTime = 36;
			item.channel = true;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 0, 24, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item44;
			item.shoot = ModContent.ProjectileType<ForestGuardianJunior>();
			item.shootSpeed = 2f;
			item.buffType = ModContent.BuffType<ForestGuardianJunior>();
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tree Branch Staff");
			Tooltip.SetDefault("Summons a forest guardian junior to fight for you.");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "树枝法杖");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "召唤一个森林守护者幼体为你而战");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Посох из ветви дерева");
			Tooltip.AddTranslation((int)GameCulture.CultureName.Russian, "Призывает младшего стража леса, который сражается за вас");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(true);
			}
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 15)
				.AddIngredient(null, "Leaf", 20)
				.AddIngredient(null, "NatureEssence", 6)
				.AddTile(16)
				.Register();
		}
	}
}
