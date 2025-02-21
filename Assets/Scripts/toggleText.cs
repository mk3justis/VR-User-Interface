using UnityEngine;
using UnityEngine.UI;

public class ToggleText : MonoBehaviour
{
    public GameObject textObject; // Assign the Text GameObject in the Inspector

    public void ToggleVisibility()
    {
        textObject.SetActive(!textObject.activeSelf);
    }
}
