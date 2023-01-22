using UnityEngine;
using UnityEngine.UI;

public class VehicleUnlock : MonoBehaviour
{
    public int totalMetalCollected = 0;

    public bool carUnlocked;
    public bool shipUnlocked;
    public bool planeUnlocked;
    public bool trainUnlocked;
    public Text targetText;
    public string newText = "NULLS";

    void Update()
    {   

        if (totalMetalCollected >= 10)
        {
            carUnlocked = true;
        }

        if (totalMetalCollected >= 20)
        {
            trainUnlocked = true;
        }

        if (totalMetalCollected >= 30)
        {
            shipUnlocked = true;
        }

        if (totalMetalCollected >= 40)
        {
            planeUnlocked = true;
        }

       newText = totalMetalCollected.ToString();

        targetText.text = newText;


    }
}
