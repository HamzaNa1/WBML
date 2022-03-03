using UnityEngine;
using WBML.Core;
using WBML.Core.GodPowers;
using WBML.Core.UI;

namespace WBML.Test
{
    public class TestMod : Mod
    {
        public override ModInfo Info => new ModInfo("lol", "xd", "a");

        public override void Initialize()
        {
            CloudGodPower power = new CloudGodPower("coffeeCloudSpawn", "Coffee Cloud", "Spawns a coffee cloud",
                "coffee", Color.yellow);

            Sprite sprite = Resources.Load<Sprite>("ui/icons/iconcoffee");

            PowerButtonBuilder
                .CreateButton()
                .WithPower(power)
                .WithIcon(sprite)
                .InTab(PowerTab.Nature)
                .BuildButton();
        }

        public override void Update()
        {
            
        }
    }
}