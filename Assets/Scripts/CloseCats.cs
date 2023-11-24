using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCats : MonoBehaviour
{
    public GameObject[] Cats;

    public void CloseCategory()
    {
        foreach(GameObject Cat in Cats)
        {
            if (Cat.GetComponent<CategoryOnClick>().open)
            {
                Cat.GetComponent<CategoryOnClick>().CloseCategory();
            }
        }
    }
}
