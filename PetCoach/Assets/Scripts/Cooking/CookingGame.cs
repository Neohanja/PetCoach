using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CookingGame : MonoBehaviour
{
    public Ingredient[] cookingIngredients;
    public Transform ingredientPlacementLocation;
    protected Transform plate;
    protected Vector3 plateLocation;
    protected List<GameObject> ingredientsAdded = new List<GameObject>();
    public TextMeshProUGUI friendSays;
    public TextMeshProUGUI scoreTotalWording;
    protected int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        if (ingredientPlacementLocation != null)
            plateLocation = ingredientPlacementLocation.position;
        if (plate == null)
            plate = new GameObject("Cooking Game Ingredients").transform;

        UpdateButtonWording();
        totalScore = 0;

        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreTotalWording.text = "Total weight contributed by food: " + totalScore.ToString();
    }

    //Adds an ingredient to the food
    public void AddIngredient(int iIndex)
    {
        ingredientPlacementLocation.position += Vector3.up * cookingIngredients[iIndex].ingredientModelSize;

        GameObject newItem = Instantiate(cookingIngredients[iIndex].ingredientModel,
            ingredientPlacementLocation.position, Quaternion.identity, plate);        

        ingredientsAdded.Add(newItem);

        if(cookingIngredients[iIndex].flavorProfile > 5)
        {
            friendSays.text = "Yum!";
        }
        else if(cookingIngredients[iIndex].flavorProfile == 5)
        {
            friendSays.text = "Meh...";
        }
        else
        {
            friendSays.text = "Yuck ?!?!?!?!";
        }

        totalScore += cookingIngredients[iIndex].weightAdded;

        UpdateScore();
    }

    public void ClearIngredients()
    {
        for(int i = ingredientsAdded.Count - 1; i >= 0; --i)
        {
            Destroy(ingredientsAdded[i]);
        }

        totalScore = 0;

        UpdateScore();
        ingredientsAdded.Clear();
    }

    protected void UpdateButtonWording()
    {
        foreach (Ingredient buttonWords in cookingIngredients)
        {
            if(buttonWords.UIButtonText != null)
            {
                buttonWords.UIButtonText.text = buttonWords.ingredientName;
            }
        }
    }

    private void OnValidate()
    {
        UpdateButtonWording();
    }
}
