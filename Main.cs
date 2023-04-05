using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2Cpp;
using System.Collections.Generic;
using static marinetower.SubTowers;

[assembly: MelonInfo(typeof(marinetower.Main), marinetower.ModHelperData.Name, marinetower.ModHelperData.Version, marinetower.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]


namespace marinetower
{

    class Main : BloonsMod
    {
        public class MarineBuffIcon : ModBuffIcon
        {
            protected override int Order => 1;
            public override string Icon => "MarineBuffIcon";
            public override int MaxStackSize => 1;
        }

        public class Marinetower : ModTower
        {
            protected override int Order => 10;
            public override string Name => "marinetower";
            public override string DisplayName => "Marine";
            public override string Description => "The Marine has a high rate, high pierce rifle.";
            public override string BaseTower => "DartMonkey";
            public override int Cost => 850;
            public override int TopPathUpgrades => 5;
            public override int MiddlePathUpgrades => 5;
            public override int BottomPathUpgrades => 5;
            public override TowerSet TowerSet => TowerSet.Military;
            public override int GetTowerIndex(List<TowerDetailsModel> towerSet) => towerSet.First(model => model.towerId == TowerType.HeliPilot).towerIndex + 1;
            public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.display = new PrefabReference() { guidRef = "0a5e9af7206332f48a8978404af1e772" };
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.ejectX = -2.08f;
                    weaponModel.ejectY = 18.84f;
                    weaponModel.ejectZ = 11.57f;

                    weaponModel.Rate = 0.5f;
                    weaponModel.projectile.pierce = 10;
                    weaponModel.projectile.GetDamageModel().damage = 1;
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "3d1e15517b50cdc4bb6c7d7666975046" };
                }
                towerModel.range = 25;
                foreach(var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range = 25;
                }
            }
            public override string Icon => "Marinetower_Icon";
            public override string Portrait => "Marinetower_Portrait";
        
        }
        public class Top1 : ModUpgrade<Marinetower>
        {
            public override string Name => "Top1";
            public override string DisplayName => "Faster rifle";
            public override string Description => "Marine shoots faster.";
            public override int Cost => 750;
            public override int Path => TOP;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.Rate *= 0.75f;
                }
            }
            public override string Icon => "Top Path 1_Icon";
            public override string Portrait => "Top Path 1_Portrait";
        }

        public class Top2 : ModUpgrade<Marinetower>
        {
            public override string Name => "Top2";
            public override string DisplayName => "Even better rifle";
            public override string Description => "Doubles the attack speed and makes bullet deal more damage.";
            public override int Cost => 1200;
            public override int Path => TOP;
            public override int Tier => 2;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.Rate *= 0.5f;
                    weaponModel.projectile.GetDamageModel().damage += 1;
                }
            }
            public override string Icon => "Top Path 2_Icon";
            public override string Portrait => "Top Path 2_Portrait";
        }

        public class Top3 : ModUpgrade<Marinetower>
        {
            public override string Name => "Top3";
            public override string DisplayName => "Moab Marine";
            public override string Description => "3 times more MOAB damage!";
            public override int Cost => 5000;
            public override int Path => TOP;
            public override int Tier => 3;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 4, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 4, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 4, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 4, false, true));
                    weaponModel.Rate = 0.15f;
                }
            }
            public override string Icon => "Top Path 3_Icon";
            public override string Portrait => "Top Path 3_Portrait";
        }

        public class Top4 : ModUpgrade<Marinetower>
        {
            public override string Name => "Top4";
            public override string DisplayName => "Knockback Training";
            public override string Description => "Stronger bullets knockback bloons.";
            public override int Cost => 20000;
            public override int Path => TOP;
            public override int Tier => 4;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var KnockbackMarine = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
                    KnockbackMarine.chance = 0.5f;
                    KnockbackMarine.distanceMin = 25;
                    KnockbackMarine.distanceMax = 50;
                var attackModel = towerModel.GetAttackModel();
                    attackModel.weapons[0].projectile.AddBehavior(KnockbackMarine);
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.pierce += 5;
                    weaponModel.projectile.GetDamageModel().damage += 3;
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 6, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 6, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 6, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 6, false, true));
                    weaponModel.Rate = 0.1f;
                }
            }
            public override string Icon => "Top Path 4_Icon";
            public override string Portrait => "Top Path 4_Portrait";
        }
        
        public class Top5 : ModUpgrade<Marinetower>
        {
            public override string Name => "Top5";
            public override string DisplayName => "Dominator of the MOABs";
            public override string Description => "Rifle gets a lot stronger and knockback now affects MOAB class bloons!";
            public override int Cost => 80000;
            public override int Path => TOP;
            public override int Tier => 5;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var KnockbackMarine = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
                    KnockbackMarine.chance = 0.05f;
                    KnockbackMarine.affectMoab = true;
                    KnockbackMarine.distanceMin = 30;
                    KnockbackMarine.distanceMax = 60;
                var attackModel = towerModel.GetAttackModel();
                    attackModel.weapons[0].projectile.AddBehavior(KnockbackMarine);
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.pierce += 5;
                    weaponModel.projectile.GetDamageModel().damage += 5;
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 55, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 80, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 230, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 190, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1, 390, false, true));
                    weaponModel.Rate = 0.05f;
                }
            }
            public override string Icon => "Top Path 5_Icon";
            public override string Portrait => "Top Path 5_Portrait";
        }

        public class Middle1 : ModUpgrade<Marinetower>
        {
            public override string Name => "Middle1";
            public override string DisplayName => "Camo training";
            public override string Description => "Marine learns to see camo bloons.";
            public override int Cost => 450;
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.AddBehavior(new OverrideCamoDetectionModel("CamoDetect", true));
                towerModel.GetAttackModel().AddBehavior(new TargetFirstPrioCamoModel("FirstPrioCamo", true, false));
                towerModel.GetAttackModel().AddBehavior(new TargetLastPrioCamoModel("LastPrioCamo", true, false));
                towerModel.GetAttackModel().AddBehavior(new TargetClosePrioCamoModel("ClosePrioCamo", true, false));
                towerModel.GetAttackModel().AddBehavior(new TargetStrongPrioCamoModel("StrongPrioCamo", true, false));
                towerModel.towerSelectionMenuThemeId = "Camo";
            }
            public override string Icon => "Middle Path 1_Icon";
            public override string Portrait => "Middle Path 1_Portrait";
        }

        public class Middle2 : ModUpgrade<Marinetower>
        {
            public override string Name => "Middle2";
            public override string DisplayName => "Further camo training";
            public override string Description => "Marine also learns to remove camo properties from bloons.";
            public override int Cost => 850;
            public override int Path => MIDDLE;
            public override int Tier => 2;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.collisionPasses = new int[] { 0, -1 };
                }
                var CamoMarine = Game.instance.model.GetTowerFromId("NinjaMonkey-020").GetWeapon().projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate<RemoveBloonModifiersModel>();
                CamoMarine.cleanseCamo = true;
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.AddBehavior(CamoMarine);
            }
            public override string Icon => "Middle Path 2_Icon";
            public override string Portrait => "Middle Path 2_Portrait";
        }

        public class Middle3 : ModUpgrade<Marinetower>
        {
            public override string Name => "Middle3";
            public override string DisplayName => "Captain";
            public override string Description => "Captain teaches nearby monkeys to shoot way faster.";
            public override int Cost => 17500;
            public override int Path => MIDDLE;
            public override int Tier => 3;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var buff = new RateSupportModel("RateSupport", 0.66f, true, "Marine:Rate", false, 1, null, null, null);
                buff.ApplyBuffIcon<MarineBuffIcon>();
                towerModel.AddBehavior(buff);

                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.pierce += 10;
                    weaponModel.projectile.GetDamageModel().damage += 10;
                }

                towerModel.range += 10;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 10;
                }
            }
            public override string Icon => "Middle Path 3_Icon";
            public override string Portrait => "Middle Path 3_Portrait";
        }

        public class Middle4 : ModUpgrade<Marinetower>
        {
            public override string Name => "Middle4";
            public override string DisplayName => "Major";
            public override string Description => "Major is granted the privilege of asking for additional support.";
            public override int Cost => 25000;
            public override int Path => MIDDLE;
            public override int Tier => 4;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.pierce += 15;
                    weaponModel.projectile.GetDamageModel().damage += 15;
                }

                var Ability = Game.instance.model.GetTower(TowerType.BombShooter, 0, 4, 0).GetAbilities()[0].Duplicate();

                AttackModel[] support = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
                support[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();

                support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<ApacheDartship>(), 0, true, false, false, true, false));
                support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<SupportChinook>(), 0, true, false, false, true, false));
                support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<ComancheDefense>(), 0, true, false, false, true, false));
                support[0].weapons[0].projectile.display = new() { guidRef = "" };

                Ability.GetBehavior<ActivateAttackModel>().attacks = support;
                Ability.maxActivationsPerRound = 9999999;
                Ability.canActivateBetweenRounds = true;
                Ability.resetCooldownOnTierUpgrade = true;
                Ability.cooldown = 45;
                Ability.icon = GetSpriteReference("Middle Path 4_Icon");

                towerModel.AddBehavior(Ability);

                towerModel.range += 10;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 10;
                }
            }
            public override string Icon => "Middle Path 4_Icon";
            public override string Portrait => "Middle Path 4_Portrait";
        }

        public class Middle5 : ModUpgrade<Marinetower>
        {
            public override string Name => "Middle5";
            public override string DisplayName => "Commandant of the Marine Corps";
            public override string Description => "As the Commandant of the Marine Corps, the marine can request any available force...";
            public override int Cost => 50000;
            public override int Path => MIDDLE;
            public override int Tier => 5;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.pierce += 5;
                    weaponModel.projectile.GetDamageModel().damage += 5;
                }

                towerModel.RemoveBehavior<AbilityModel>();

                var newAbility = Game.instance.model.GetTower(TowerType.BombShooter, 0, 5, 0).GetAbilities()[0].Duplicate();

                AttackModel[] newsupport = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
                newsupport[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();

                newsupport[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<ApachePrime>(), 0, true, false, false, true, false));
                newsupport[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<SpecialPoperations>(), 0, true, false, false, true, false));
                newsupport[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<ComancheCommander>(), 0, true, false, false, true, false));
                newsupport[0].weapons[0].projectile.display = new() { guidRef = "" };

                newAbility.GetBehavior<ActivateAttackModel>().attacks = newsupport;
                newAbility.maxActivationsPerRound = 9999999;
                newAbility.canActivateBetweenRounds = true;
                newAbility.resetCooldownOnTierUpgrade = true;
                newAbility.cooldown = 45;
                newAbility.icon = GetSpriteReference("Middle Path 5_Icon");

                towerModel.AddBehavior(newAbility);

                towerModel.range += 10;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 10;
                }
            }
            public override string Icon => "Middle Path 5_Icon";
            public override string Portrait => "Middle Path 5_Portrait";
        }

        public class Bottom1 : ModUpgrade<Marinetower>
        {
            public override string Name => "Bottom1";
            public override string DisplayName => "Advanced Technology";
            public override string Description => "Allows the Marine's rifle to shoot through walls.";
            public override int Cost => 400;
            public override int Path => BOTTOM;
            public override int Tier => 1;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ignoreBlockers = true;
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "6c11e1432d6321c44b216600b2cdbac6" };
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple | BloonProperties.Lead;
                }

                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.weapons[0].projectile.ignoreBlockers = true;
                    attackModel.weapons[0].projectile.canCollisionBeBlockedByMapLos = false;
                    attackModel.attackThroughWalls = true;
                }
            }
            public override string Icon => "Bottom Path 1_Icon";
            public override string Portrait => "Bottom Path 1_Portrait";
        }

        public class Bottom2 : ModUpgrade<Marinetower>
        {
            public override string Name => "Bottom2";
            public override string DisplayName => "Seeking rifle";
            public override string Description => "His rifle will never miss bloons again.";
            public override int Cost => 1750;
            public override int Path => BOTTOM;
            public override int Tier => 2;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "5f1f09b0c6b6a3447b9e70e14d68869a" };
                    var attackModel = towerModel.GetAttackModel();
                    var TrackMarine = Game.instance.model.GetTowerFromId("WizardMonkey-500").GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate<TrackTargetModel>();
                    TrackMarine.distance = 999;
                    TrackMarine.constantlyAquireNewTarget = true;
                    weaponModel.projectile.GetBehavior<TravelStraitModel>().lifespan = 1.4f;
                    weaponModel.projectile.pierce += 10;
                    attackModel.weapons[0].projectile.AddBehavior(TrackMarine);
                }
            }
            public override string Icon => "Bottom Path 2_Icon";
            public override string Portrait => "Bottom Path 2_Portrait";
        }

        public class Bottom3 : ModUpgrade<Marinetower>
        {
            public override string Name => "Bottom3";
            public override string DisplayName => "Sun blasting bullets";
            public override string Description => "Shoots 2 powerful sun beams, that burn bloons on contact.";
            public override int Cost => 35000;
            public override int Path => BOTTOM;
            public override int Tier => 3;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.GetWeapon().emission = new RandomArcEmissionModel("ArcEmissionModel_", 2, 0, 15, 8, 1, null);

                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "5737e26c93d5fc149ade2f7df1156c74" };
                    weaponModel.projectile.pierce += 5;
                    weaponModel.projectile.GetDamageModel().damage += 2;
                    weaponModel.projectile.GetBehavior<TravelStraitModel>().speed = 560;
                    weaponModel.rate *= 0.75f;
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                }

                towerModel.range += 10;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 10;
                    var Fire = Game.instance.model.GetTowerFromId("DartlingGunner-200").Duplicate<TowerModel>().GetBehavior<AttackModel>().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>();
                    Fire.lifespan = 4;
                    Fire.overlayType = "Fire";
                    attackModel.weapons[0].projectile.AddBehavior(Fire);
                    attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(Fire);
                    attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.collisionPasses = new int[] { 0, 1 };
                }
            }
            public override string Icon => "Bottom Path 3_Icon";
            public override string Portrait => "Bottom Path 3_Portrait";
        }

        public class Bottom4 : ModUpgrade<Marinetower>
        {
            public override string Name => "Bottom4";
            public override string DisplayName => "Plasmarine";
            public override string Description => "High energy plasma can pop every bloon type.";
            public override int Cost => 70000;
            public override int Path => BOTTOM;
            public override int Tier => 4;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.GetWeapon().emission = new RandomArcEmissionModel("ArcEmissionModel_", 4, 0, 80, 8, 1, null);

                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "72288b06ef230b644976478047ff0768" };
                    weaponModel.projectile.pierce += 20;
                    weaponModel.projectile.GetDamageModel().damage += 28;
                    weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                }
                
                towerModel.range += 15;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 15;    
                }
            }
            public override string Icon => "Bottom Path 4_Icon";
            public override string Portrait => "Bottom Path 4_Portrait";
        }

        public class Bottom5 : ModUpgrade<Marinetower>
        {
            public override string Name => "Bottom5";
            public override string DisplayName => "Vengeful Marine";
            public override string Description => "No words can describe his power...";
            public override int Cost => 750000;
            public override int Path => BOTTOM;
            public override int Tier => 5;
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {
                    weaponModel.rate *= 0.5f;
                    weaponModel.projectile.display = new PrefabReference() { guidRef = "4fb0baaa656410f4ba1f2fd07b37eda4" };
                    weaponModel.projectile.pierce = 100;
                    weaponModel.projectile.GetDamageModel().damage = 50;
                    //very op yes
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 50, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 100, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 200, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 200, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1, 450, false, true));
                }

                towerModel.range += 20;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    attackModel.range += 20;
                }

                AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
                Avatarspawner[0].weapons[0].rate = 45;
                Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<VengefulAvatar>(), 0, true, false, false, true, false));
                Avatarspawner[0].weapons[0].projectile.display = new() { guidRef = "" };
                towerModel.AddBehavior(Avatarspawner[0]);
            }
            public override string Icon => "Bottom Path 5_Icon";
            public override string Portrait => "Bottom Path 5_Portrait";
        }
    }
}