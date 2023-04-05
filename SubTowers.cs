using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace marinetower
{
    internal class SubTowers
    {
        public class ApacheDartship : ModTower
        {
            protected override int Order => 1;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-402";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Apache Dartship";
            public override bool DontAddToShop => true;
            public override string Description => "Adds a large missile array and powerful machine guns.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-402").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
            }
        }
        public class SupportChinook  : ModTower
        {
            protected override int Order => 2;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-240";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Support Chinook";
            public override bool DontAddToShop => true;
            public override string Description => "Abilities: Drops lives and cash crates, or can pick up and redeploy most Monkey types.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-240").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
                towerModel.RemoveBehaviors<AbilityModel>();
            }
        }
        public class ComancheDefense : ModTower
        {
            protected override int Order => 3;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-204";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Comanche Defense";
            public override bool DontAddToShop => true;
            public override string Description => "Automatically calls in mini Comanches when they're most needed.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-204").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
            }
        }
        public class ApachePrime : ModTower
        {
            protected override int Order => 4;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-502";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Apache Prime";
            public override bool DontAddToShop => true;
            public override string Description => "The Apache Prime leaves most Bloons wishing they'd never been inflated.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-502").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
            }
        }
        public class SpecialPoperations : ModTower
        {
            protected override int Order => 5;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-250";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Special Poperations";
            public override bool DontAddToShop => true;
            public override string Description => "Deploys a powerful special Monkey Marine with machine gun.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-250").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
                towerModel.RemoveBehaviors<AbilityModel>();
            }
        }
        public class ComancheCommander : ModTower
        {
            protected override int Order => 6;
            public override TowerSet TowerSet => TowerSet.Military;
            public override string BaseTower => "HeliPilot-205";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Comanche Commander";
            public override bool DontAddToShop => true;
            public override string Description => "Upgraded weapons. Also automatically calls in 3 more Comanches. Permanently.";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;
                towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("HeliPilot-205").portrait;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.GetBehavior<TowerExpireModel>().lifespan = 15;
                towerModel.display = new PrefabReference() { guidRef = "" };
                towerModel.GetAttackModel().RemoveBehavior<FollowTouchSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<LockInPlaceSettingModel>();
                towerModel.GetAttackModel().RemoveBehavior<PatrolPointsSettingModel>();
            }
        }
        public class VengefulAvatar : ModTower
        {
            //If the BaseTower is set to "TrueSunAvatarMini", the Avatar doesn't shoot until an actual Sun God is placed.
            //If the BaseTower is set to "SuperMonkey-300", it plays the upgrade sound, every time the Marine places down an avatar!
            //That's why I chose "DartMonkey".
            protected override int Order => 7;
            public override TowerSet TowerSet => TowerSet.Magic;
            public override string BaseTower => "DartMonkey";
            public override int Cost => 0;
            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;

            public override string Name => "Vengeful Sun Avatar";
            public override bool DontAddToShop => true;
            public override string Description => "Vengeful Sun Avatar";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.isSubTower = true;

                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("TrueSunAvatarMini").GetBehavior<TowerExpireModel>().Duplicate());
                towerModel.display = new PrefabReference() { guidRef = "36d3f05381187cf4da168f4676076159" };

                towerModel.ignoreBlockers = true;
                towerModel.GetWeapon().emission = new RandomArcEmissionModel("ArcEmissionModel_", 3, 0, 30, 8, 1, null);
                towerModel.range = 50;

                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "e4abb3d789fca4747a7459d21c835472" };
                    weaponModel.ejectX = 0f;
                    weaponModel.ejectY = 5.4f;
                    weaponModel.ejectZ = 12.9f;
                    weaponModel.projectile.GetBehavior<TravelStraitModel>().speed = 560;
                    weaponModel.projectile.GetBehavior<TravelStraitModel>().lifespan = 0.6f;
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                    weaponModel.rate = 0.03f;
                    weaponModel.projectile.pierce = 6;
                    weaponModel.projectile.GetDamageModel().damage = 20;
                }

                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range = 50;
                    attackModel.weapons[0].projectile.ignoreBlockers = true;
                    attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
                    attackModel.attackThroughWalls = true;
                }
            }
            public override string Icon => "VengefulAvatar";
            public override string Portrait => "VengefulAvatar";
        }
    }
}