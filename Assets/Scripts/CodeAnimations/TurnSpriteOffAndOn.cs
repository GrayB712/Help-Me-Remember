using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSpriteOffAndOn : MonoBehaviour
{

    private SpriteRenderer myImage;

    public float timeBetweenSwitches;
    private float timer = 0f;
    private bool imageOn = true;

    public bool switchGraphics = true;

    Color currentColor;

    void Start(){
        myImage = GetComponent<SpriteRenderer>();
        currentColor = myImage.color;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!switchGraphics){
            return;
        }

        timer += Time.deltaTime;

        if(timer > timeBetweenSwitches){

            float newAlpha = 1f;
            if(imageOn){
                newAlpha = 0f;
            }

            myImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            imageOn = !imageOn;

            timer = 0f;
        }

        
    }
}
