using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Category openness = new Category();
        Category conscientiousness = new Category();
        Category extraversion = new Category();
        Category agreeableness = new Category();
        Category neuroticism = new Category();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
 * How I'm going about this:
 * I spent a little while trying to figure out what I actually was trying to do.
 * I decided that it would be best for me to create these 2 classes in the GameController.
 * I wanted to make another script that would create our trait object, though since we are 
 * using a button for each of the traits, I think I might leave that for you guys to figure out.
 * The classes are currently set up for another script on an object.
 */
public class Category
{
    List<Trait> traits = new List<Trait>();
    List<Trait> selected = new List<Trait>();
    public Category() { }

    public void addTrait(Trait _t)
    {
        traits.Add(_t);
    }

    public void SelectionMade(Trait _t)
    {
        for (int i = 0; i < traits.Count; i++)
        {
            if (traits[i] == _t)
            {
                selected.Add(traits[i]);
            }
        }
    }
}

public class Trait
{
    int pT = 0;
    string name = "";
    Image img;
    public Trait(int _pT, string _name, Image _img)
    {
        this.pT = _pT;
        this.name = _name;
        this.img = _img;
    }

    public string GetName()
    {
        return name;
    }
}
