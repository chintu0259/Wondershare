using System;
using System.Collections.Generic;
using UnityEngine;
using static GameDatasSO;

public class CardGridGenerator 
{
	GameDatasSO gameDatas;

	List<int> availableImageIndexes;
	List<int> availablePositionIndexes;

	int cardCount;

	public CardGridGenerator(GameDatasSO gameData)
	{
        gameDatas=gameData;
        cardCount = gameDatas.level[gameDatas.levelIndex].rows * gameDatas.level[gameDatas.levelIndex].columns;

		GenerateAvailableImageIndexes();
		GenerateAvailablePositionIndexes(cardCount);
	}

	public CardSO GetRandomAvailableCardSO()
	{
		int random = UnityEngine.Random.Range(0, this.availableImageIndexes.Count);
		int randomIndex = availableImageIndexes[random];

		availableImageIndexes.RemoveAt(random);

		return gameDatas.cards[randomIndex];
	}

    public CardSO GetCardPairSO(string cardPairName)
    {
        foreach (CardSO card in gameDatas.cards)
        {
            if (card.IsPair(cardPairName))
            {
                return card;
            }
        }

        return null;
    }

    public int GetRandomCardPositionIndex()
	{
		int randomIndex = UnityEngine.Random.Range(0, availablePositionIndexes.Count);
		int randomPosition = availablePositionIndexes[randomIndex];

		availablePositionIndexes.RemoveAt(randomIndex);

		return randomPosition;
	}

	void GenerateAvailableImageIndexes()
	{
		availableImageIndexes = new List<int>();
		int index = gameDatas.cards.Count;

		for(int i = 0; i < index; i++)
		{
			if (i % 2 == 0)
			{
				this.availableImageIndexes.Add(i);
			}
		}
	}

	private void GenerateAvailablePositionIndexes(int cardCount)
	{
		availablePositionIndexes = new List<int>();

		for (int i = 0; i < cardCount; i++)
		{
			availablePositionIndexes.Add(i);
		}
	}
}
