using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public Selectable[] topStacks;
    public GameObject highScorePanel;

    private Solitaire solitaire;

    public int score = -52;
    public bool vegasCumulative = false;

    public void ResetVegasDebit()
    {
        if (!vegasCumulative)
        {
            score = -52;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        solitaire = FindObjectOfType<Solitaire>();
        if (!solitaire.vegasCumulative)
        {
            solitaire.score = -52;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HasWon())
        {
            Win();
        }
    }

    public bool HasWon()
    {
        int totalValue = 0;
        foreach (Selectable topstack in topStacks)
        {
            totalValue += topstack.value;
        }
        return totalValue >= 52;
    }

    void Win()
    {
        highScorePanel.SetActive(true);
        if (solitaire.vegasCumulative)
        {
            print("You have won! Total Score: " + solitaire.score);
        }
        else
        {
            print("You have won! Score: " + (solitaire.score + 52));
        }
    }
}
