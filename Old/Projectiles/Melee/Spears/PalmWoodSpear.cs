﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
	public class PalmWoodSpear : ModProjectile
	{
		public float movementFactor
		{
			get
			{
				return projectile.ai[0];
			}
			set
			{
				projectile.ai[0] = value;
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.aiStyle = 19;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.scale = 1.3f;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.alpha = 0;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Spear");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "棕榈木矛");
			DisplayName.AddTranslation((int)GameCulture.CultureName.Russian, "Копье из пальмовой древесины");
		}

		public override void AI()
		{
			Player owner = null;
			if (projectile.owner != -1)
			{
				owner = Main.player[projectile.owner];
			}
			else if (projectile.owner == 255)
			{
				owner = Main.LocalPlayer;
			}
			Player player = owner;
			Player projOwner = player;
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - projectile.width / 2;
			projectile.position.Y = ownerMountedCenter.Y - projectile.height / 2;
			if (!projOwner.frozen)
			{
				if (movementFactor == 0f)
				{
					movementFactor = 3f;
					projectile.netUpdate = true;
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
				{
					movementFactor -= 2.4f;
				}
				else
				{
					movementFactor += 2.1f;
				}
			}
			projectile.position += projectile.velocity * movementFactor;
			if (projOwner.itemAnimation == 0)
			{
				projectile.Kill();
			}
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + MathHelper.ToRadians(135f);
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation -= MathHelper.ToRadians(90f);
			}
		}
	}
}
