using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI buttonNextTMP;

    private static ModalScript instance;
    private string titleDefault;
    private string messageDefault;
    private string buttonNextDefault;

    void Start()
    {
        instance = this;
        titleDefault = titleTMP.text;
        messageDefault = messageTMP.text;
        buttonNextDefault = buttonNextTMP.text;
        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive( !content.activeInHierarchy );
        }
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
        if (GameState.isLevelFailed)
        {
            SceneManager.LoadScene(GameState.levelIndex);
        }
        else if (GameState.isLevelCompleted)
        {
            GameState.levelIndex += 1; 
            if(GameState.levelIndex >= SceneManager.sceneCountInBuildSettings)
            {
                GameState.levelIndex = 0;
            }
            SceneManager.LoadScene(GameState.levelIndex);
        }
    }

    public void OnExitButtonClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void _Show(string title = null, string message = null, string buttonNext = null)
    {
        Time.timeScale = 0.0f;       
        content.SetActive(true);
        if (title != null) titleTMP.text = title;
        else titleTMP.text = titleDefault;

        if (message != null) messageTMP.text = message;
        else messageTMP.text = messageDefault;

        if (buttonNext != null) buttonNextTMP.text = buttonNext;
        else buttonNextTMP.text = buttonNextDefault;
    }
    public static void ShowModal(string title = null, string message = null, string buttonNext = null)
    {
        instance._Show(title, message, buttonNext);
    }
}
