using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public bool[] traits;

    public GameData(List<Category> categories)
    {
        traits = new bool[15];
        for (int i = 0; i < categories.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                traits[i * 3 + j] = categories[i].traits[j].GetIsSelected();
                Debug.LogError( (i * 3 + j) + " is " + traits[i * 3 + j]);
            }
        }
    }
}
