using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Panel_HUD;
    public GameObject Panel_GameOver;


    void TurnOFFAllPanels()
    {
        Panel_HUD.SetActive(false);
        Panel_GameOver.SetActive(false);

    }


    public void Show_Panel_HUD()
    {
        TurnOFFAllPanels();
        Panel_HUD.SetActive(true);
    }
    public void Show_Panel_GameOver()
    {
        TurnOFFAllPanels();
        Panel_GameOver.SetActive(true);
    }
}
