using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int killPoints;
    private int maxKills;
    private bool isPause;

    public Text killText;
    public GameObject panel;
    public Text header;
    public Text label;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        killText.text = "Kills: " + killPoints;
        panel.SetActive(false);

        if (PlayerPrefs.HasKey("Kills"))
            maxKills = PlayerPrefs.GetInt("Kills");
    }

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void IncKills()
    {
        killPoints += 1;
        if (killText)
            killText.text = "Kills: " + killPoints;
    }

    public void GameOver()
    {
        panel.SetActive(true);
        header.text = "Game Over";
        label.text = string.Format("Your Score: {0}\nBest Score: {1}", killPoints, maxKills);
        if (killPoints > maxKills)
            PlayerPrefs.SetInt("Kills", killPoints);
    }

    public void Pause()
    {
        isPause = !isPause;
        panel.SetActive(isPause);
        header.text = "Pause";
        label.text = string.Format("Your Score: {0}\nBest Score: {1}", killPoints, maxKills);
        Time.timeScale = isPause ? 0 : 1;
    }
}
