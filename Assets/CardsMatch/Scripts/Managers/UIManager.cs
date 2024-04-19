using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Panel_HUD;
    public GameObject Panel_GameOver;

    public GameObject Panel_Combo;

    public TextMeshProUGUI text_matches;
    public TextMeshProUGUI text_moves;
    public TextMeshProUGUI text_Score;
    void TurnOFFAllPanels()
    {
        Panel_HUD.SetActive(false);
        Panel_GameOver.SetActive(false);
        Panel_Combo.SetActive(false);

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
    public void UpdateScoreText(int scoreCount)
    {

        text_Score.text = scoreCount.ToString();
    }

    public void Show_Panel_Combo()
    {
        AudioManager.instance.Play(4);
        Panel_Combo.SetActive(true);
        StartCoroutine(Hide_Panel_Combo());
    }

    IEnumerator Hide_Panel_Combo()
    {
        yield return new WaitForSeconds(3);
        Panel_Combo.SetActive(false);
    }

}
