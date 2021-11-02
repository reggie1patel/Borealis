using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public float Timer = 1f;
    public float WaitTimer1 = 1.5f;

    void Update()
    {
		Timer += Time.deltaTime;
		if (Timer < WaitTimer1)
		{
			StartCoroutine(FadeTo(1.0f, 1.0f));
		}
        else if (Timer > WaitTimer1)
        {
			StartCoroutine(FadeTo(0.0f, 1.0f));
		}
		
    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
    }
}
