using UnityEngine;
using UnityEngine.UI;

public class ShipHealthBar : MonoBehaviour
{
    private Slider healthBar;
    [HideInInspector] public ShipData thisShip;
    public Vector3 healthBarOffset = new Vector3(0, 1.15f, 0);

    void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = thisShip.transform.position + healthBarOffset;
    }

    public void UpdateValue(float value, int maxValue)
    {
        float normalizedHealth = value / maxValue;
        if(healthBar != null)
        {
            healthBar.value = normalizedHealth;
        }
    }
}
