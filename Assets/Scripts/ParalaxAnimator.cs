using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ParalaxAnimator : MonoBehaviour
{
    public float paralaxScale = 1f;

    private Vector3 originalPosition;

    public bool flippedDirection = true;

    public void OnEnable(){
        originalPosition = transform.position;
    }

    public void OnDisable(){
        transform.position = originalPosition;
    }

    public void Update(){

        // Gets X-screen position of mouse as scaled float between -1 and 1
        float currentMouseParalaxPosition = GetMouseParalaxPosition();

        if(flippedDirection){

            MoveToParalaxPosition(-currentMouseParalaxPosition);

        } else {

            // Moves the gameobject this script is attached to based on the mouse position.
            MoveToParalaxPosition(currentMouseParalaxPosition);

        }

        
    }

    // Returns a float between -1 and 1 for the mouse's screen position. 0 is the middle of the screen.
    private float GetMouseParalaxPosition(){

        float screenWidth = Screen.width;
        
        float scaledMousePosition = ((Mouse.current.position.ReadValue().x/screenWidth) * 2f) - 1f;

        //Debug.Log("Scale mouse position. Should be -1 thru 1: " + scaledMousePosition);

        if(scaledMousePosition < -1f){
            return -1f;
        } else if(scaledMousePosition > 1f){
            return 1f;
        } else {
            return scaledMousePosition;
        }        

    }

    // Accepts float between -1 and 1 for the mouse's position on screen. Moves paralax object that direction.
    private void MoveToParalaxPosition(float paralaxPercent){

        //Debug.Log("Paralax percent: " + paralaxPercent);

        if(paralaxPercent > 1f || paralaxPercent < -1f){
            Debug.LogError("Invalid mouse input value for paralax operation.");
            return;
        }
        
        float minXPosition = originalPosition.x - paralaxScale;
        float maxXPosition = originalPosition.x + paralaxScale;

        Debug.Log("Min position: " + minXPosition);
        Debug.Log("Max position: " + maxXPosition);

        float movementRange = maxXPosition - minXPosition;

        float adjustedParalaxPercent = (paralaxPercent + 1f) / 2f;

        float currentXPosition = minXPosition + (adjustedParalaxPercent * movementRange);

        //Debug.Log()

        transform.position = new Vector3(currentXPosition, transform.position.y, transform.position.z);

    }
}
