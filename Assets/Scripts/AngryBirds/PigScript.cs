using UnityEngine;

public class PigScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bird")
        {
            ModalScript.ShowModal("ЗНИЩЕНО", "-1 супротивник");
        }
        Debug.Log(collision.gameObject.name);
    }
}
