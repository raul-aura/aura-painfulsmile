using UnityEngine;
using UnityEngine.UI;

public class DataSlider : MonoBehaviour
{
    private Slider sliderObj;
    public Text sliderValueText;
    public DataTypes sliderData;
    [SerializeField] private float minValue, maxValue;
    [SerializeField] private string textSuffix = " minutes";

    void Start()
    {
        sliderObj = GetComponent<Slider>();
        CalculateSliderValue();
    }

    public void CalculateSliderValue()
    {
        float newValue = sliderObj.value * (maxValue - minValue) + minValue;
        sliderValueText.text = newValue.ToString("F1") + textSuffix;
        GameInstance.Instance.ChangeData(sliderData, newValue);
    }
}

public enum DataTypes
{
    GAMESESSION,
    ENEMYSPAWN
}
