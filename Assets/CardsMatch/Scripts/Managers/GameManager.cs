using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameDatasSO gameDatasSO;
    public UIManager uIManager;
	public GridManager gridManager;


    GameState gameState;
    public CardSelectionState cardSelectionState;
    public MemorizeCardsState memorizeCardsState;
    public MatchingCardsState matchingCardsState;

    public GameObject[] selectedCards;

	int cardCount;

	int movesCount;
    int matchesCount;
    int scoreCount;

    int comboCount=0;
    int comboMoveCount=0;
    bool isGameOver = false;
   

    public int CardCount
	{
		set
		{
			cardCount = value;
		}
		get
		{
			return cardCount;
		}
	}

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameDatasSO.levelIndex=PlayerPrefs.GetInt(GameDatasSO.LEVELINDEX, 0);
        comboCount = 0;
        comboMoveCount = 0;
        isGameOver = false;
        uIManager.Show_Panel_HUD();

        movesCount = 0;
        matchesCount=0;
        scoreCount = PlayerPrefs.GetInt(GameDatasSO.SCORE, 0);
        selectedCards = new GameObject[2];
        selectedCards[0] = null;
        selectedCards[1] = null;

        InitStates();
        gridManager.GenerateGrid();
    }

    void Update()
    {
        gameState.UpdateAction();

        if (cardCount <= 0 && !isGameOver)
        {
            isGameOver = true;
            gameDatasSO.levelIndex++;
            if(gameDatasSO.levelIndex > gameDatasSO.level.Count-1)
            {
                gameDatasSO.levelIndex = 0;
            }
            PlayerPrefs.SetInt(GameDatasSO.LEVELINDEX ,gameDatasSO.levelIndex);
            AudioManager.instance.Play(3);
            StartCoroutine(ShowGameOver());
        }
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(3);
        uIManager.Show_Panel_GameOver();
    }

    void InitStates()
    {
        cardSelectionState = new CardSelectionState(this);
        memorizeCardsState = new MemorizeCardsState(this, 0.5f);
        matchingCardsState = new MatchingCardsState(this, 0.2f);

        gameState = cardSelectionState;
    }

    public void TransitionState(GameState newState)
    {
        gameState.EndState();
        gameState = newState;
        gameState.EnterState();
    }

    public void SetSelectedCard(GameObject selectedCard)
    {
        movesCount++;
        uIManager.UpdateMovesText(movesCount);

        if (selectedCards[0] == null)
        {
            selectedCards[0] = selectedCard;

        }
        else if (selectedCards[1] == null)
        {
            selectedCards[1] = selectedCard;

            if (MatchSelectedCards())
            {
                matchesCount++;
                scoreCount++;
                PlayerPrefs.SetInt(GameDatasSO.SCORE, scoreCount);
                TransitionState(matchingCardsState);
                uIManager.UpdateMatchesText(matchesCount);
                uIManager.UpdateScoreText(scoreCount);

                if(comboCount==0)
                {
                    comboCount++;
                    comboMoveCount = movesCount + 2;
                }
                if (comboCount == 1)
                {
                    comboCount=0;
                    if (movesCount ==comboMoveCount)
                    {
                        comboMoveCount = 0;
                        if (gameDatasSO.levelIndex>0)
                        {
                            uIManager.Show_Panel_Combo();
                        }
                    }
                }

            }
            else
            {
                TransitionState(memorizeCardsState);
            }
        }
    }

    public void PlayComboText()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void RemoveSelectedCards()
	{
		selectedCards[0] = null;
		selectedCards[1] = null;
	}

	bool MatchSelectedCards()
	{
		GameDatasSO.CardSO first = selectedCards[0].GetComponent<CardController>().cardType;
		GameDatasSO.CardSO second = selectedCards[1].GetComponent<CardController>().cardType;

		return first != null && second != null && first.cardName == second.cardName;
	}

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
