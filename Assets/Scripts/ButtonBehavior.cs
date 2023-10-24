using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    //This function calls the SelectTrait function from the GameController.
    public void TraitNum(int traitNum)
    {
        GameObject.Find("Backend").GetComponent<GameController>().SelectTrait(traitNum);
        Debug.Log("Trait Number: " + traitNum);
    }
}
