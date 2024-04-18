using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Caliberly/GameData")]
public class GameDatasSO : ScriptableObject
{

    [SerializeField]public List<CardSO> level;
    [SerializeField] public List<CardSO> cards;

    [System.Serializable]
    public class Level
    {
        [SerializeField] public int rows;
        [SerializeField] public int columns;
        [SerializeField] public int preferredPaddingTopBottom;
        [SerializeField] public Vector2 spacing;
    }

    [System.Serializable]
    public class CardSO
    {
        [SerializeField] public string cardName;
        [SerializeField] public string pairName;
        [SerializeField] public Sprite cardImage;

        public bool IsPair(string givenName)
        {
            givenName = givenName.ToLower();

            return (givenName == pairName);
        }
    }
}
