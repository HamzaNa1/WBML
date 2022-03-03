using UnityEngine;
using UnityEngine.UI;
using WBML.Core.GodPowers;
using WBML.Utility;

namespace WBML.Core.UI;

public class PowerButtonBuilder :
    ISelectPowerStage,
    ISelectIconStage,
    ISelectTabStage,
    IBuildStage
{
    private string _id = string.Empty;
    private string _name = string.Empty;
    private string _description = string.Empty;
    private Sprite _sprite;
    private string _tab = string.Empty;
    
    public static ISelectPowerStage CreateButton()
    {
        return new PowerButtonBuilder();
    }

    public ISelectIconStage WithPower(Power power)
    {
        _id = power.Id;
        _name = power.Name;
        _description = power.Description;
        return this;
    }

    public ISelectTabStage WithIcon(Sprite sprite)
    {
        _sprite = sprite;
        return this;
    }

    public IBuildStage InTab(string tab)
    {
        _tab = tab;
        return this;
    }

    public IBuildStage InTab(PowerTab tab)
    {
        _tab = "Tab_" + tab;
        return this;
    }

    public GameObject BuildButton()
    {
        LocalizationUtils.Add(_name, _name);
        LocalizationUtils.Add(_name + " Description", _description);

        GameObject tempObj = PowerButton.get("cloudSnow").gameObject;
        tempObj.SetActive(false);
        GameObject gameObject = Object.Instantiate(tempObj);
        tempObj.SetActive(true);
        gameObject.name = _id;

        Button button = gameObject.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick = new Button.ButtonClickedEvent();

        Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
        image.sprite = _sprite;

        PowerButton powerButton = gameObject.GetComponent<PowerButton>();
        powerButton.type = PowerButtonType.Active;
        powerButton.open_window_id = string.Empty;
        PowerButton.powerButtons.Add(powerButton);

        GameObject tab = ObjectFinder.Find(_tab);

        if (tab is not null)
        {
            PowersTab powersTab = tab.GetComponent<PowersTab>();
            Transform transform = powerButton.transform;

            transform.SetParent(powersTab.transform);
            transform.localPosition = new Vector2(680.6f + 36, -18);
            transform.localScale = new Vector2(1f, 1f);
        }
        
        gameObject.SetActive(true);

        return gameObject;
    }
}

public interface ISelectPowerStage
{
    ISelectIconStage WithPower(Power power);
}

public interface ISelectIconStage
{
    ISelectTabStage WithIcon(Sprite sprite);
}

public interface ISelectTabStage
{
    IBuildStage InTab(string tab);
    IBuildStage InTab(PowerTab tab);
}

public interface IBuildStage
{
    GameObject BuildButton();
}