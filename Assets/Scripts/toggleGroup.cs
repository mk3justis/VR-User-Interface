using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Weekend : MonoBehaviour
{
    public List<Toggle> toggles = new();
    public TextMeshProUGUI result;
    private string choice;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var toggle in toggles)
        {
            toggle.onValueChanged.AddListener(state =>
            {
                choice = toggle.name;
            });
        }
    }

    public void Submit()
    {
        if (string.IsNullOrEmpty(choice) || toggles.All(t => !t.isOn))
        {
            result.text = "Pick one!";
        }
        else
        {
            result.text = "I also love " + choice + "!";
        }
    }
}
