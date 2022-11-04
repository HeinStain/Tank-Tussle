using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkEffect : MonoBehaviour
{
    
    private Text text;
    [SerializeField] private float fadeDuration = 5;
    [SerializeField] private float fadePause = 1;
    [SerializeField] private float elapsedTime = 0f;
    
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        StartCoroutine("Blink");
    }

    IEnumerator Blink()
    {
        while(true)
        {
            yield return StartCoroutine(Fade(1f));
            yield return new WaitForSeconds(fadePause);
            yield return StartCoroutine(Fade(0f));
            yield return new WaitForSeconds(fadePause);
        }
        
    }

    IEnumerator Fade(float targetAlpha)
    {
        Debug.Log("Fading to " + targetAlpha);

        Color initialColor = text.color;
        if (targetAlpha == 1)
        {
            initialColor = new Color(1f, 1f, 1f, 0f);
        }
        else if (targetAlpha == 0)
        {
            initialColor = new Color(1f, 1f, 1f, 1f);
        }
        
        Color targetColor = new Color(1f, 1f, 1f, targetAlpha);

        elapsedTime = 0f;

        while(elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            text.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }
    }
   
}
