using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameDatasSO;

public class GridManager : MonoBehaviour
{
	public GameObject cardPrefab;
    public GameDatasSO gameDatasSO;

	
	CardGridGenerator cardGridGenerator;

	List<CardController> cardControllers;

	public void GenerateGrid()
	{
		cardControllers = new List<CardController>();

		cardGridGenerator = new CardGridGenerator(gameDatasSO);

		SetCardGridLayoutParams();
		GenerateCards();

		GameManager.instance.CardCount = gameDatasSO.level[gameDatasSO.levelIndex].rows * gameDatasSO.level[gameDatasSO.levelIndex].columns;
	}

	private void SetCardGridLayoutParams()
	{
		CardGridLayout cardGridLayout = this.GetComponent<CardGridLayout>();

		cardGridLayout.preferredPadding = gameDatasSO.level[gameDatasSO.levelIndex].preferredPaddingTopBottom;
		cardGridLayout.rows = gameDatasSO.level[gameDatasSO.levelIndex].rows;
		cardGridLayout.columns = gameDatasSO.level[gameDatasSO.levelIndex].columns;
		cardGridLayout.spacing = gameDatasSO.level[gameDatasSO.levelIndex].spacing;

		cardGridLayout.Invoke("CalculateLayoutInputHorizontal", 0.1f);
	}


	private void GenerateCards()
	{
		int cardCount = gameDatasSO.level[gameDatasSO.levelIndex].rows * gameDatasSO.level[gameDatasSO.levelIndex].columns;

		for(int i = 0; i < cardCount; i++)
		{
			GameObject card = Instantiate(cardPrefab, this.transform);
			card.transform.name = "Card (" + i.ToString() + ")";

			cardControllers.Add(card.GetComponent<CardController>());
		}

		for(int i = 0; i < cardCount/ 2; i++)
		{
            GameDatasSO.CardSO randomCard = cardGridGenerator.GetRandomAvailableCardSO();
			SetRandomCardToGrid(randomCard);

            CardSO randomCardPair = cardGridGenerator.GetCardPairSO(randomCard.cardName);
            SetRandomCardToGrid(randomCardPair);
        }
	}

	private void SetRandomCardToGrid(GameDatasSO.CardSO randomCard)
	{
		int index = cardGridGenerator.GetRandomCardPositionIndex();
		CardController cardObject = cardControllers[index];
		cardObject.SetCardDatas(gameDatasSO.level[gameDatasSO.levelIndex].background, randomCard);
	}
}
