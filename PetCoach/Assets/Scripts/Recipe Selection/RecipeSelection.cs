using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeSelection : MonoBehaviour
{
    [HideInInspector] public string selectedRecipe;
    public void PlayWeightLoss1()
    {
        selectedRecipe = "Salad";
        SceneManager.LoadScene(3);
    }
    public void PlayWeightGain1()
    {
        //SceneManager.LoadScene();
    }
    public void PlayMaintainWeight1()
    {
        //SceneManager.LoadScene();
    }
    public void QuitGame()
    {
        Debug.Log("Quit has been selected.");
        Application.Quit();
    }
}
