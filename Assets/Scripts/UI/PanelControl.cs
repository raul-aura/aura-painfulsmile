using UnityEngine;

public class PanelControl : MonoBehaviour
{
    private GameObject currentPanel;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject endSessionPanel;
    [SerializeField] private GameObject background;

    void Start()
    {
        MainMenu(false);
    }

    public void PlayButton(bool forceReset)
    {
        if(forceReset)
        {
            GameInstance.Instance.ResetGame();
        }
        background.SetActive(false);
        currentPanel.SetActive(false);
        GameInstance.Instance.GameModeProperty = GameModes.PLAY;
    }

    public void ChangePanel(GameObject panel)
    {
        if(panel != currentPanel && currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        panel.SetActive(true);
        currentPanel = panel;
    }

    public void MainMenu(bool forceReset)
    {
        if(forceReset)
        {
            GameInstance.Instance.ResetGame();
        }
        ChangePanel(mainMenuPanel);
    }

    public void EndSession()
    {
        background.SetActive(true);
        ChangePanel(endSessionPanel);
    }
}
