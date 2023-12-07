using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.Animations;

public class GameController : MonoBehaviour
{
    public List<Category> categories = new List<Category>();
    public int psychTokens = 6;
    public GameObject ptWarningPanel;
    public GameObject saveConfirmationPanel;
    public GameObject loadConfirmationPanel;
    bool canSave = false; // only switches to true when player has chosen trait in each category

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Save").GetComponent<Button>().interactable = false;

        List<Category.Trait> traits1 = new List<Category.Trait>();
        traits1.Add(new Category.Trait(0, "Close-minded", "Characters with this trait are resistant \nto new experiences and find it hard \nto think outside the box. They tend to stick \nto what they know and avoid novel \nsituations.", GameObject.Find("Openness0")));
        traits1.Add(new Category.Trait(1, "Open-minded", "These characters are curious about the world \nand are open to trying new things, but \nmay not always seek them out actively.", GameObject.Find("Openness1")));
        traits1.Add(new Category.Trait(2, "Visionary Explorer", "Characters with this trait have an \ninsatiable curiosity. They are constantly \nseeking out new experiences, ideas, and challenges. \nThey are often seen as innovators and thought leaders.", GameObject.Find("Openness2")));
        categories.Add(new Category("Openness", traits1));
        List<Category.Trait> traits2 = new List<Category.Trait>();
        traits2.Add(new Category.Trait(0, "Careless", "Characters with this trait can be disorganized, \nforgetful, and often fail to fulfill their \nresponsibilities. They might struggle with \nsetting and achieving goals.", GameObject.Find("Conscientiousness0")));
        traits2.Add(new Category.Trait(1, "Conscientious", "These characters generally meet their \nresponsibilities and are relatively organized. \nThey try to do what's expected of them, but might \nsometimes fall short.", GameObject.Find("Conscientiousness1")));
        traits2.Add(new Category.Trait(2, "Relentless Achiever", "Characters with this trait are extremely \norganized, responsible, and driven. They set \nhigh standards for themselves and will go \nabove and beyond to meet their goals.", GameObject.Find("Conscientiousness2")));
        categories.Add(new Category("Conscientiousness", traits2));
        List<Category.Trait> traits3 = new List<Category.Trait>();
        traits3.Add(new Category.Trait(0, "Recluse", "Characters with this trait prefer solitude and \noften feel drained in social situations. They tend to \navoid group activities and can be seen as loners.", GameObject.Find("Extraversion0")));
        traits3.Add(new Category.Trait(1, "Sociable", "These characters enjoy socializing to an extent, \nbut also appreciate alone time. They have a balance \nbetween their social and private life.", GameObject.Find("Extraversion1")));
        traits3.Add(new Category.Trait(2, "Charismatic Dynamo", "Characters with this trait thrive in social \nsituations and often become the life of the party. \nThey are energetic, assertive, and draw \nothers to them with their magnetic personality.", GameObject.Find("Extraversion2")));
        categories.Add(new Category("Extraversion", traits3));
        List<Category.Trait> traits4 = new List<Category.Trait>();
        traits4.Add(new Category.Trait(0, "Contrarian", "Characters with this trait can be argumentative, \ncritical, and might have a hard time getting \nalong with others. They often prioritize their \nown needs over others.", GameObject.Find("Agreeableness0")));
        traits4.Add(new Category.Trait(1, "Amicable", "These characters generally get along with others and \ntry to maintain harmony. They may occasionally have \ndisagreements but generally value relationships.", GameObject.Find("Agreeableness1")));
        traits4.Add(new Category.Trait(2, "Empathic Diplomat", "Characters with this trait are extremely understanding, \nkind, and value harmony above all else. They often \ngo out of their way to help others and avoid \nconflicts.", GameObject.Find("Agreeableness2")));
        categories.Add(new Category("Agreeableness", traits4));
        List<Category.Trait> traits5 = new List<Category.Trait>();
        traits5.Add(new Category.Trait(0, "Volatile", "Characters with this trait are often emotionally unstable, \nexperiencing frequent mood swings and high levels \nof stress. They can be seen as unpredictable.", GameObject.Find("Neuroticism0")));
        traits5.Add(new Category.Trait(1, "Balanced", "These characters have a reasonable handle on their emotions. \nThey experience ups and downs, but generally can \nmanage their reactions and stress levels.", GameObject.Find("Neuroticism1")));
        traits5.Add(new Category.Trait(2, "Steadfast Optimist", "Characters with this trait are exceptionally emotionally stable \nand often maintain a positive outlook. They handle \nstress with grace and are rarely shaken by \nnegative events.", GameObject.Find("Neuroticism2")));
        categories.Add(new Category("Neuroticism", traits5));
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
        checkCategories();

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

        if (canSave)
        {
            GameObject.Find("Save").GetComponent<Button>().interactable = true;
        }
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(categories);
        saveConfirmationPanel.SetActive(true);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        loadConfirmationPanel.SetActive(true);

        for (int i = 0; i < categories.Count; i++)
        {
            categories[i].DeselectAll();
        }
        psychTokens = 6;

        for (int i = 0; i < data.traits.Length; i++)
        {

            if (data.traits[i])
            {
                SelectTrait(i);
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

        public bool GetIsSelected()
        {
            return isSelected;
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
                //GameObject.Find(traits[i].GetName()).GetComponent<Button>().interactable = true;
                GameObject.Find(categoryName).transform.GetChild(2+i).GetComponent<Button>().interactable = true;

                traits[i].Deselect();
            }
            else{
                traits[i].Select();
                //GameObject.Find(traits[i].GetName()).GetComponent<Button>().interactable = false;
                GameObject.Find(categoryName).transform.GetChild(2 + i).GetComponent<Button>().interactable = false;
            }
        }
    }

    public void DeselectAll()
    {
        isTraitSelected = false;
        selected = 0;
        for (int i = 0; i < traits.Count; i++)
        {
            //GameObject.Find(traits[i].GetName()).SetActive(true);

            GameObject.Find(categoryName).transform.GetChild(2 + i).GetComponent<Button>().interactable = true;
            traits[i].Deselect();
            //GameObject.Find(traits[i].GetName()).SetActive(false);


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

    public string getName()
    {
        return categoryName;
    }
}




