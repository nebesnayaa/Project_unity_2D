using UnityEngine;

public class TriesCountScript : MonoBehaviour
{
    [SerializeField]
    private int tries;
    public static int triesCount;

    private TMPro.TextMeshProUGUI triesCountTMP;
    void Start()
    {
        triesCountTMP = GetComponent<TMPro.TextMeshProUGUI>();
        triesCount = tries;
    }


    void Update()
    {
        if (triesCountTMP.text != triesCount.ToString())
        {
            triesCountTMP.text = triesCount.ToString();
        }
    }
}
