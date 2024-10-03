using System.Collections;
using TMPro;
using UnityEngine;

public class MessageBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;

    void Start()
    {
        StartCoroutine(ShowTextForDuration(introductionField, "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.", 5f));
    }

    // Generalized method for showing text on any TMP_Text field for a specified duration
    private IEnumerator ShowTextForDuration(TMP_Text textField, string message, float duration)
    {
        textField.enabled = true;
        textField.text = message;
        yield return new WaitForSeconds(duration);
        textField.enabled = false;
    }

    public IEnumerator ShowMessage(string message)
    {
        yield return StartCoroutine(ShowTextForDuration(messageField, message, 3f));
    }
}
