using UnityEngine;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;

    private static ModalScript instance;
    private string titleDefault;
    private string messageDefault;

    void Start()
    {
        instance = this;
        titleDefault = titleTMP.text;
        messageDefault = messageTMP.text;
        if(content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
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
        content.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnExitButtonClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void _Show(string title = null, string message = null)
    {
        Time.timeScale = 0.0f;       
        content.SetActive(true);
        if (title != null) titleTMP.text = title;
        else titleTMP.text = titleDefault;

        if (message != null) messageTMP.text = message;
        else messageTMP.text = messageDefault;
    }
    public static void ShowModal(string title = null, string message = null)
    {
        instance._Show(title, message);
    }
}
