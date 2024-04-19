using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Caliberly/GameData")]
public class GameDatasSO : ScriptableObject
{
    public static string LEVELINDEX = "levelIndex";
    public static string SCORE = "score";

    public int levelIndex = 0;
    [SerializeField]public List<Level> level;
    [SerializeField] public List<CardSO> cards;

    [System.Serializable]
    public class Level
    {
        [SerializeField] public int rows;
        [SerializeField] public int columns;
        [SerializeField] public int preferredPaddingTopBottom;
        [SerializeField] public Vector2 spacing;
        public Sprite background;
    }

    [System.Serializable]
    public class CardSO
    {
        [SerializeField] public string cardName;
        [SerializeField] public Sprite cardImage;

        public bool IsPair(string givenName)
        {
            givenName = givenName.ToLower();

            return (givenName == cardName);
        }

    }
}
