using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject centeredText;

    public void ShowCenteredText(string message)
    {
        try
        {
            if (centeredText == null)
            {
                throw new System.NullReferenceException("Centered Text GameObject is not assigned.");
            }
            centeredText.SetActive(true);
            centeredText.GetComponentInChildren<Text>().text = message;

        }
        catch (System.Exception ex)
        {
            Debug.LogError($"An error occurred while showing centered text: {ex.Message}");
        }
    }
    public void HideCenteredText()
    {
        try
        {
            if (centeredText == null)
            {
                throw new System.NullReferenceException("Centered Text GameObject is not assigned.");
            }
            centeredText.SetActive(false);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"An error occurred while hiding centered text: {ex.Message}");
        }
    }
}
