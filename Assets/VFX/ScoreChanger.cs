using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ScoreChanger : MonoBehaviour
{

    private Text text;
    private RectTransform rectTrans;

    private Coroutine routine;
    private Vector2 originalScale;
    float t=0;
    public Vector2 desiredScale;
    public float duration=0.2f;
    private void Start()
    {



        text = GetComponent<Text>();
        rectTrans = GetComponent<RectTransform>();
        originalScale = rectTrans.localScale;


    }

  /*  public void Update()
    {
        if (Input.anyKeyDown) {
            SetValue(Random.Range(-100f, 100f));
        }
    }*/

    public void SetValue(float newValue)
    {


        text.text = newValue.ToString();
        if (routine != null) {
            StopCoroutine(routine);
            rectTrans.localScale = originalScale;
        }

        StartCoroutine(textResize(desiredScale,duration));


    }

    public void SetTime (string t)
    {
        text.text = t;
    }




    IEnumerator textResize(Vector3 newSize, float time)
    {
    
        while (t < time) {
    

            t += Time.deltaTime;

            rectTrans.localScale = Vector2.Lerp(rectTrans.localScale, newSize, t);
         yield return new   WaitForEndOfFrame();

        }
        t = 0;
        while (t < time) {


            t += Time.deltaTime;

            rectTrans.localScale = Vector2.Lerp(rectTrans.localScale , originalScale , t);


            yield return new WaitForEndOfFrame();

        }
        rectTrans.localScale = originalScale;
        t = 0;


    }




}
