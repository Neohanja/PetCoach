using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PetFriend : MonoBehaviour
{
    [Header("UI Connection Elements")]
    public Text uiFriendResponse;
    public Button nextOption;

    [Header("Dialog Options")]
    public DialogOptions[] friendDialogChoices;

    [Header("UI Options")]
    public float responseTimer;
    float elapsedTimer;
    bool startTimer;
    public bool useButtonToContinueDialog;

    void Start()
    {
        ResetFriendDialog();

        foreach(DialogOptions speak in friendDialogChoices)
        {
            if(speak.uiPlayerButtonText.text != speak.playerChoice)
            {
                speak.uiPlayerButtonText.text = speak.playerChoice;
            }
        }
    }

    void Update()
    {
        if(startTimer && !useButtonToContinueDialog)
        {
            elapsedTimer += Time.deltaTime;

            if(elapsedTimer >= responseTimer)
            {
                ResetFriendDialog();
            }
        }
    }

    //More functions can be added to determine the mini-game used later on, such as if a rhythm game or cooking game,
    //style of cooking game, ect.
    public void GotoCookingMinigame()
    {
        SceneManager.LoadScene("Cooking");
    }

    /// <summary>
    /// Turns the player options back on and can be used to remove any "friend" reponse effects
    /// </summary>
    public void ResetFriendDialog()
    {
        elapsedTimer = 0f;
        uiFriendResponse.text = "";
        startTimer = false;

        if (nextOption != null) nextOption.gameObject.SetActive(false);

        foreach (DialogOptions dialog in friendDialogChoices)
        {
            if (dialog.uiPlayerButtonText != null)
            {
                dialog.uiPlayerButtonText.transform.parent.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Run this when a dialog option is selected.
    /// </summary>
    public void SelectedDialog(int option)
    {
        startTimer = true;

        //Clamps values to avoid the game from breaking.
        if (option < 0) option = 0;
        if (option >= friendDialogChoices.Length) option = friendDialogChoices.Length - 1;

        uiFriendResponse.text = friendDialogChoices[option].friendResponse;
        if (useButtonToContinueDialog && nextOption != null) nextOption.gameObject.SetActive(true);

        foreach (DialogOptions dialog in friendDialogChoices)
        {
            if (dialog.uiPlayerButtonText != null)
            {
                dialog.uiPlayerButtonText.transform.parent.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Once the options are input, automatically updates in the game view for the player options.
    /// </summary>
    void OnValidate()
    {
        foreach(DialogOptions dialog in friendDialogChoices)
        {
            if(dialog.uiPlayerButtonText != null)
            {
                dialog.uiPlayerButtonText.text = dialog.playerChoice;
            }
        }
    }
}
