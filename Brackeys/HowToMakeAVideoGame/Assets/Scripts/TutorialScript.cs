using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public Text tutorialText; // Reference to the Text component

    void Start()
    {
        // Initialize tutorial text to be empty at the start
        if (tutorialText != null)
        {
            tutorialText.text = "";
        }
    }

    public void SetTutorialText(string text)
    {
        // Update the tutorial text
        if (tutorialText != null)
        {
            tutorialText.text = text;
        }
    }

    public void ClearTutorialText()
    {
        // Clear the tutorial text
        if (tutorialText != null)
        {
            tutorialText.text = "";
        }
    }
}
