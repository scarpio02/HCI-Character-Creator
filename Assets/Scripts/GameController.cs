using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class GameController : MonoBehaviour
{
    public List<Category> categories = new List<Category>();
    public int psychTokens = 6;
    public GameObject ptWarningPanel;
    bool canSave = false; // only switches to true when player has chosen trait in each category

    // Start is called before the first frame update
    void Start()
    {
        List<Category.Trait> traits1 = new List<Category.Trait>();
        traits1.Add(new Category.Trait(0, "Closed-minded", "Characters with this trait are resistant to new experiences and find it hard to think outside the box. They tend to stick to what they know and avoid novel situations.", GameObject.Find("Openness0")));
        traits1.Add(new Category.Trait(1, "Open-minded", "These characters are curious about the world and are open to trying new things, but may not always seek them out actively.", GameObject.Find("Openness1")));
        traits1.Add(new Category.Trait(2, "Visionary Explorer", "Characters with this trait have an insatiable curiosity. They are constantly seeking out new experiences, ideas, and challenges. They are often seen as innovators and thought leaders.", GameObject.Find("Openness2")));
        categories.Add(new Category("Openness", traits1));
        List<Category.Trait> traits2 = new List<Category.Trait>();
        traits2.Add(new Category.Trait(0, "Careless", "Characters with this trait can be disorganized, forgetful, and often fail to fulfill their responsibilities. They might struggle with setting and achieving goals.", GameObject.Find("Conscientiousness0")));
        traits2.Add(new Category.Trait(1, "Conscientious", "These characters generally meet their responsibilities and are relatively organized. They try to do what's expected of them, but might sometimes fall short.", GameObject.Find("Conscientiousness1")));
        traits2.Add(new Category.Trait(2, "Relentless Achiever", "Characters with this trait are extremely organized, responsible, and driven. They set high standards for themselves and will go above and beyond to meet their goals.", GameObject.Find("Conscientiousness2")));
        categories.Add(new Category("Conscientiousness", traits2));
        List<Category.Trait> traits3 = new List<Category.Trait>();
        traits3.Add(new Category.Trait(0, "Recluse", "Characters with this trait prefer solitude and often feel drained in social situations. They tend to avoid group activities and can be seen as loners.", GameObject.Find("Extraversion0")));
        traits3.Add(new Category.Trait(1, "Sociable", "These characters enjoy socializing to an extent, but also appreciate alone time. They have a balance between their social and private life.", GameObject.Find("Extraversion1")));
        traits3.Add(new Category.Trait(2, "Charismatic Dynamo", "Characters with this trait thrive in social situations and often become the life of the party. They are energetic, assertive, and draw others to them with their magnetic personality.", GameObject.Find("Extraversion2")));
        categories.Add(new Category("Extraversion", traits3));
        List<Category.Trait> traits4 = new List<Category.Trait>();
        traits4.Add(new Category.Trait(0, "Contrarian", "Characters with this trait can be argumentative, critical, and might have a hard time getting along with others. They often prioritize their own needs over others.", GameObject.Find("Agreeableness0")));
        traits4.Add(new Category.Trait(1, "Amicable", "These characters generally get along with others and try to maintain harmony. They may occasionally have disagreements but generally value relationships.", GameObject.Find("Agreeableness1")));
        traits4.Add(new Category.Trait(2, "Empathic Diplomat", "Characters with this trait are extremely understanding, kind, and value harmony above all else. They often go out of their way to help others and avoid conflicts.", GameObject.Find("Agreeableness2")));
        categories.Add(new Category("Agreeableness", traits4));
        List<Category.Trait> traits5 = new List<Category.Trait>();
        traits5.Add(new Category.Trait(0, "Volatile", "Characters with this trait are often emotionally unstable, experiencing frequent mood swings and high levels of stress. They can be seen as unpredictable.", GameObject.Find("Neuroticism0")));
        traits5.Add(new Category.Trait(1, "Balanced", "These characters have a reasonable handle on their emotions. They experience ups and downs, but generally can manage their reactions and stress levels.", GameObject.Find("Neuroticism1")));
        traits5.Add(new Category.Trait(2, "Steadfast Optimist", "Characters with this trait are exceptionally emotionally stable and often maintain a positive outlook. They handle stress with grace and are rarely shaken by negative events.", GameObject.Find("Neuroticism2")));
        categories.Add(new Category("Neuroticism", traits5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectTrait(int traitNum){
        int categoryNum = traitNum / 3;
        int traitIndex = traitNum % 3;
        psychTokens += categories[categoryNum].getSelected();
        if (categories[categoryNum].getTraitPT(traitIndex) <= psychTokens)
        {
            categories[categoryNum].newSelect(traitIndex);
        }
        else
        {
            ptWarningPanel.SetActive(true);
        }
        psychTokens -= categories[categoryNum].getSelected();
        GameObject.Find("GreenBar").GetComponent<PTMeter>().updateMeter();

    }

    public int getPsychTokens()
    {
        return psychTokens;
    }

    public void checkCategories()
    {
        canSave = true;
        for (int i = 0; i < categories.Count; i++)
        {
            if (!categories[i].getIsTraitSelected())
            {
                canSave = false;
            }
        }
    }

}

/*
 * Tim's Notes:
 * How I'm going about this:
 * I spent a little while trying to figure out what I actually was trying to do.
 * I decided that it would be best for me to create these 2 classes in the GameController.
 * I wanted to make another script that would create our trait object, though since we are 
 * using a button for each of the traits, I think I might leave that for you guys to figure out.
 * The classes are currently set up for another script on an object.
 */

/*
   Josh's Notes:
   I've wrapped the trait class within the category class, and added a few functions for making selections.
   Currently, the information flow is intended as such:
   The user clicks on one of the buttons in the ui. That button has a value that it passes in to the GameController via the SelectTrait function.
   The GameController then uses that value to determine which category and trait to select. (This is done by division and modulo operations.)
   The buttons for traits are numbered 0-14, starting with tier 0 of openmindedness, going to tier 2 of neuroticism in a clockwise circle.
   The GameController then calls the newSelect function on the category, which deselects all traits in the category except for the one selected.
   It also selects the passed in trait.
   I have also added descriptions for the categories and traits in the start function of the GameController.
   I have not implemented any features regarding token cost, aside from a couple mentions of the cost in functions in case they're needed later.
   This implementation will be left to whoever comes next.
   If you have any questions, feel free to reach out, hopefully I will remember my code :P
*/

/*
    Santiago's Notes:
    Added token pt tracking with token costs. Also checks that selection only occurs if there's enough tokens available.
    Added a meter for the psych tokens that will update when selecting traits. I plan to add a warning message when the user
    tries to use more tokens than they have.
    Came up with ideas for possible images for each trait. Will work further on how the actual character generation/saving will look.
 */
public class Category
{
    string categoryName = "";
    public List<Trait> traits = new List<Trait>();
    int selected = 0;
    bool isTraitSelected = false;

    public class Trait
    {   
        int pT = 0;
        string name = "";
        string description = "";
        bool isSelected;
        GameObject img;
        public Trait() { }

        public Trait(int _pT, string _name, string _description, GameObject _img)
        {
            this.pT = _pT;
            this.name = _name;
            this.description = _description;
            this.isSelected = false;
            this.img = _img;
            img.SetActive(false);

        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetPTString()
        {
            return pT.ToString();
        }

        public int GetPT()
        {
            return pT;
        }

        public GameObject GetImage()
        {
            return img;
        }

        public int Select(){
            isSelected = true;
            img.SetActive(true);
            return pT;
        }

        public int Deselect(){
            isSelected = false;
            img.SetActive(false);
            return pT;
        }
    }
    
    public Category() { }

    public Category(string _categoryName, List<Trait> _traits){
        this.categoryName = _categoryName;
        this.traits = _traits;
    }

    public void newSelect(int traitNum){
        isTraitSelected = true;
        selected = traitNum;
        for (int i = 0; i < traits.Count; i++){
            if (i != traitNum){
                traits[i].Deselect();
            }
            else{
                traits[i].Select();
            }
        }
    }

    public int getSelected()
    {
        return selected;
    }

    public int getTraitPT(int traitNum)
    {
        return traits[traitNum].GetPT();
    }

    public bool getIsTraitSelected()
    {
        return isTraitSelected;
    }

}




