using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSpritesBackAndForth : MonoBehaviour
{
    public GameObject ImageOne;
    public GameObject ImageTwo;

    public float timeBetweenSwitches;
    private float timer = 0f;
    private bool imageOn = true;

    public bool switchGraphics = true;

    //Color currentColor;

    void Start(){
        //myImage = GetComponent<SpriteRenderer>();
        //currentColor = myImage.color;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!switchGraphics){
            return;
        }

        timer += Time.deltaTime;

        if(timer > timeBetweenSwitches){


            if(imageOn){
                ImageOne.SetActive(false);
                ImageTwo.SetActive(true);
            } else{
                ImageOne.SetActive(true);
                ImageTwo.SetActive(false);
            }

            //myImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            imageOn = !imageOn;

            timer = 0f;
        }

        
    }
}
