using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Panel_HUD;
    public GameObject Panel_GameOver;

    public TextMeshProUGUI text_matches;
    public TextMeshProUGUI text_moves;
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

    public void UpdateMatchesText(int matchesCount)
    {
        text_matches.text = matchesCount.ToString();
    }
    public void UpdateMovesText(int movesCount)
    {
        text_moves.text = movesCount.ToString();
    }

}
