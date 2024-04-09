using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    public GameObject highScorePanel;
    public Text scoreText; // Reference to the UI Text element displaying the score
    private Solitaire solitaire; // Reference to the Solitaire script

    // Start is called before the first frame update
    void Start()
    {
        // Ensure scoreText is assigned in the Unity Editor
        if (scoreText == null)
        {
            Debug.LogError("Score Text object is not assigned in the UIButtons script!");
        }

        // Find and store a reference to the Solitaire script
        solitaire = FindObjectOfType<Solitaire>();

        // Update the score text initially
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
    }

    public void ResetScene()
    {
        // Reset Vegas score debit
        ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetVegasDebit();

        // Find all the cards and remove them
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        foreach (UpdateSprite card in cards)
        {
            Destroy(card.gameObject);
        }

        // Clear top values
        ClearTopValues();

        // Deal new cards
        solitaire.PlayCards();

        // Update the score text after resetting the scene
        UpdateScoreText();
    }

    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }

    // Update the score text with the current game score
    void UpdateScoreText()
    {
        if (scoreText != null && solitaire != null)
        {
            scoreText.text = "Score: " + solitaire.gameScore;
        }
    }
}
