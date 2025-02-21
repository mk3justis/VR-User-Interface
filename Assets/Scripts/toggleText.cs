using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
    public GameObject textObject; // Assign the Text GameObject in the Inspector
    public Image image;
    int i = 0;
    public void ToggleVisibility()
    {
        textObject.SetActive(!textObject.activeSelf);
        if (i % 2 == 0)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
        i+=1;
    }
}
