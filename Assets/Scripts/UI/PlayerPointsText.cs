using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsText : MonoBehaviour
{
    private Text pointsText;

    [SerializeField] private string textPrefix = "Total points: ";

    void Start()
    {
        pointsText = GetComponent<Text>();
    }

    void Update()
    {
        UpdateText(PlayerPoints.Instance.GetPoints());
    }

    public void UpdateText(int points)
    {
        pointsText.text = textPrefix + points.ToString();
    }
}
