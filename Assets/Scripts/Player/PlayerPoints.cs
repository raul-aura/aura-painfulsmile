using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    private static PlayerPoints thisInstance;
    public static PlayerPoints Instance { get { return thisInstance; } }

    private int playerPoints = 0;
    [SerializeField] private PlayerPointsText pointsTextClass;

    private void Awake()
    {
        if (thisInstance != null && thisInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            thisInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void AddPoints()
    {
        playerPoints++;
    }

    public int GetPoints()
    {
        return playerPoints;
    }

    public void ResetPoints()
    {
        playerPoints = 0;
    }
}
