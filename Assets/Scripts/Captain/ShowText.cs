using System.Collections;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] private string[] dialogue;//array of text sentences
    [SerializeField]private TextMeshProUGUI textcomponent;//the component thats used to display text
    int counter = 0;

    /// <summary>
    /// function that shows a dialogue text on the screen
    /// </summary>
    /// <param name="index">index of the sentence in the array</param>
    public void showText(int index = -1){
        //if no index given, use the counter
        if(index < 0)
            index = counter;
        textcomponent.text = dialogue[index];

        StartCoroutine(hideText());
    }

    /// <summary>
    /// removes the text after 10 seconds
    /// </summary>
    IEnumerator hideText(){
        yield return new WaitForSeconds(10);
        textcomponent.text = "";
    }

    /// <summary>
    /// moves the counter to the next text
    /// </summary>
    public void NextText(){
        if(counter < dialogue.Length -1){
            counter++;
        }
    }
}
