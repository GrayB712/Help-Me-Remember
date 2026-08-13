using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBackAndForth : MonoBehaviour
{
    public float lowerCap = .5f;

    public float upperCap = 1f;

    public float offsetFade = 0f;
    private float fadingTimer = 0f;
    public float timeToFade = .5f;
    private float percentageFaded;
    public int fadeDirection = 1;
    private Color currentColor;
    private float originalFadeAmount = 1f;

    private SpriteRenderer myImage;

    void Start(){
        myImage = GetComponent<SpriteRenderer>();

        currentColor = myImage.color;

        originalFadeAmount = upperCap;//myImage.color.a;
        //myImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, 255f);
    }


    void Update()
    {
        //Fades Image
        fadingTimer += Time.deltaTime;

        if(fadingTimer > (5f * (2f))){
            fadingTimer = 0f;
        }

        percentageFaded = originalFadeAmount * ( ( (Mathf.Cos((fadingTimer * Mathf.PI) + offsetFade)) * 0.5f ) + 0.5f );

        percentageFaded = lowerCap + ((upperCap - lowerCap) * percentageFaded);

        myImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, percentageFaded);


    }
}
