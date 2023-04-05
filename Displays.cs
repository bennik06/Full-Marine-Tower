using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using System.Linq;
using static marinetower.Main;

namespace marinetower
{
    internal class Displays
    {
        public class MarineBaseDisplay : ModTowerDisplay<Marinetower>
        {
            public override string BaseDisplay => GetDisplay(TowerType.Marine);

            public override bool UseForTower(int[] tiers)
            {
                return tiers.Sum() == 0;
            }

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                SetMeshTexture(node, Name);
            }
        }

        public class Top5Display : ModTowerDisplay<Marinetower>
        {
            public override string BaseDisplay => GetDisplay(TowerType.Marine);

            public override bool UseForTower(int[] tiers)
            {
                return tiers[0] == 5;
            }

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                SetMeshTexture(node, Name);
            }
        }

        public class Middle5Display : ModTowerDisplay<Marinetower>
        {
            public override string BaseDisplay => GetDisplay(TowerType.Marine);

            public override bool UseForTower(int[] tiers)
            {
                return tiers[1] == 5;
            }

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                SetMeshTexture(node, Name);
            }
        }

        public class Bottom4Display : ModTowerDisplay<Marinetower>
        {
            public override string BaseDisplay => GetDisplay(TowerType.Marine);

            public override bool UseForTower(int[] tiers)
            {
                return tiers[2] == 4;
            }

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                SetMeshTexture(node, Name);
            }
        }

        public class Bottom5Display : ModTowerDisplay<Marinetower>
        {
            public override float Scale => 1.05f;
            public override string BaseDisplay => GetDisplay(TowerType.Marine);

            public override bool UseForTower(int[] tiers)
            {
                return tiers[2] == 5;
            }

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                SetMeshTexture(node, Name);
            }
        }
    }
}
