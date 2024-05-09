using UnityEngine;
using TMPro;
using System.Collections;

public class ScreenKey : MonoBehaviour
{
    public TMP_Text keyText;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    keyText.text = "Command: " + keyCode.ToString();

                    StartCoroutine(ClearTextAfterDelay(0.2f));
                    break;
                }
            }
        }
    }

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        keyText.text = "";
    }
}
