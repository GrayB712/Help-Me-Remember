using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShakeGraphic : MonoBehaviour
{
    public bool shakeHorizontal = false;

    public float timeToShakeGraphic;
    public float shakeSpeed = 1700f;

    public float _ShakeSpeed;
    public float ShakeSpeed {
        get{
            return _ShakeSpeed;
        }
        set{
            _ShakeSpeed = value;
        }
    }
    private bool currentlyShaking = false;
    private bool returnToOriginalPosition = false;
    private float _graphicYPosition;
    private float graphicYPosition {
        get{
            return _graphicYPosition;
        }
        set{
            _graphicYPosition = value;
        }
    }
    private int directionToShake;
    

    void Start()
    {
        ShakeSpeed = shakeSpeed;

        if(!shakeHorizontal){
            graphicYPosition = transform.position.y;
        } else{
            graphicYPosition = transform.position.x;
        }
        
    }

    //Wiggles the errors for emphasis! That way the user knows what they're doing wrong.
    public void ShakeItUp(){
        Debug.Log("Trying to shake it up!");
        if(!currentlyShaking){
            currentlyShaking = true;
            directionToShake = -1;
            StartCoroutine(changeShakeDirection());
        }
    }

    //Changes the direction of the wiggles
    private IEnumerator changeShakeDirection(){
        float timeUnit = timeToShakeGraphic/10f;
        yield return new WaitForSeconds(timeUnit*3f);
        directionToShake *= -1;
        yield return new WaitForSeconds(timeUnit*7f);
        currentlyShaking = false;
        returnToOriginalPosition = true;
        if(transform.position.y > graphicYPosition){
            directionToShake = -1;
        } else{
            directionToShake = 1;
        }

    }

    void Update()
    {
        
        //Wiggles the graphic back and forth, like it's bouncing on a trampoline it got for its birthday
        if(currentlyShaking){
            if(!shakeHorizontal){
                transform.position += new Vector3( 0f, Time.deltaTime * ShakeSpeed * directionToShake, 0f );
            } else{
                transform.position += new Vector3(Time.deltaTime * ShakeSpeed * directionToShake, 0f, 0f );
            }
            
        }
        //returns graphic to original position, after shaking is over
        if(returnToOriginalPosition){
            
            if(!shakeHorizontal){

                transform.position +=  new Vector3( 0f, Time.deltaTime * ShakeSpeed * directionToShake, 0f );
                if(((graphicYPosition - transform.position.y) * directionToShake ) < 0f){
                    transform.position = new Vector3(transform.position.x, graphicYPosition, transform.position.z);
                    returnToOriginalPosition = false;
                }

            } else {

                //Ignore that the variable is named "graphicYPosition". I was too lazy to change it.
                transform.position += new Vector3( Time.deltaTime * ShakeSpeed * directionToShake, 0f, 0f );
                if(((graphicYPosition - transform.position.x) * directionToShake ) < 0f){
                    transform.position = new Vector3(graphicYPosition, transform.position.y, transform.position.z);
                    returnToOriginalPosition = false;
                }

            }
            
        }

    }
}
