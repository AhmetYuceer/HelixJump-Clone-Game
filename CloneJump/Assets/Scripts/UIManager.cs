using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool endPanelisOpen;
    [SerializeField] GameObject endPanel;
    private void Update()
    {
        if (endPanelisOpen)
        {
            endPanel.SetActive(true);
        }
        else
        {
            endPanel.SetActive(false);
        }   
    }
}
