using UnityEngine;

public class FlashObjectOffAndOn : MonoBehaviour
{
    public float timeToFlash = .6f;

    public GameObject flashingObject;

    private float timer = 0f;

    private bool objectIsOn = true;


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeToFlash){

            if(objectIsOn){
                flashingObject.SetActive(false);
            } else{
                flashingObject.SetActive(true);
            }

            objectIsOn = !objectIsOn;

            timer = 0f;
        }

    }

}
