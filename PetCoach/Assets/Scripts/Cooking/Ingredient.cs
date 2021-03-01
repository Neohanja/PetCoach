using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ingredient
{
    public enum FoodCategory { DietFood, NormalFood, FattyFood };

    public string ingredientName;
    public GameObject ingredientModel;    
    public FoodCategory ingredientType;
    public float ingredientModelSize;
    public int flavorProfile;
    public int weightAdded;
    public Text UIButtonText;
}
