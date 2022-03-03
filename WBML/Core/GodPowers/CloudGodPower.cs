using System;
using UnityEngine;
using WBML.Utility;

namespace WBML.Core.GodPowers;

public class CloudGodPower : Power
{
    private readonly string _dropId;
    private readonly Color _cloudColor;

    public CloudGodPower(string id, string name, string description, string dropId, Color cloudColor) : base(id, name, description)
    {
        _dropId = dropId;
        _cloudColor = cloudColor;
        
        GodPower power = AssetManager.powers.get("_spawnSpecial");
        power.id = id;
        AssetManager.powers.add(power);
        power.name = name;
        power.click_action = SpawnCloud;
    }
    
    private bool SpawnCloud(WorldTile pTile, string pPower)
    {
        Cloud cloud = MapBox.instance.cloudController.getNext();

        cloud.CallMethod("prepare", pTile.posV3, pPower);
        
        Type cloudTypeEnum = cloud.GetField("type").GetType();
        cloud.SetField("type", Enum.Parse(cloudTypeEnum, "acid"));
        
        cloud.SetField("dropID", _dropId);
        
        cloud.sprRenderer.color = _cloudColor;

        return true;
    }
}