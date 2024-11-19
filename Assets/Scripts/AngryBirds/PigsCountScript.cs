using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PigsCountScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI pigsCountTMP;
    

    void Start()
    {
        pigsCountTMP = GetComponent<TMPro.TextMeshProUGUI>();

        GameState.needRecalculatePigs = true;
    }


    void Update()
    {
        if (GameState.needRecalculatePigs)
        {
            int pigsCount = GameObject.FindGameObjectsWithTag("Pig").Length;
            pigsCountTMP.text = pigsCount.ToString();
            GameState.needRecalculatePigs = false;
            GameState.isLevelCompleted = pigsCount == 0;
            GameState.isLevelFailed = pigsCount != 0;
            
            if(pigsCount == 0)
            {
                if (GameState.levelIndex + 1 == SceneManager.sceneCountInBuildSettings)
                {
                    GameState.isGameCompleted = true;
                    ModalScript.ShowModal("ГРУ ПРОЙДЕНО", "Ви успішно пройшли всю гру, бажаєте почати заново?", "З початку");
                }
                else
                {
                    ModalScript.ShowModal("УСПІХ", "Рівень пройдено, знищено всіх ворогів!");
                }
            }
        }
    }
}
