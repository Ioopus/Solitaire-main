using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Dropdown Dropdown; // Dropdown for selecting game options

    // Start is called before the first frame update
    void Start()
    {
        // Load the player's preferences for game options
        Dropdown.value = PlayerPrefs.GetInt("Dropdown", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to start a new game
    public void StartGame()
    {
        // Save the selected option to player's preferences
        PlayerPrefs.SetInt("SelectedOption", Dropdown.value);

        // Load the game scene based on the selected option
        switch (Dropdown.value)
        {
            case 0: // Regular option
                PlayerPrefs.SetInt("VegasOption", 0);
                PlayerPrefs.SetInt("Draw3Option", 0);
                break;
            case 1: // Vegas option
                PlayerPrefs.SetInt("VegasOption", 1);
                PlayerPrefs.SetInt("Draw3Option", 0);
                break;
            case 2: // Draw3 option
                PlayerPrefs.SetInt("VegasOption", 0);
                PlayerPrefs.SetInt("Draw3Option", 1);
                break;
        }

        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
