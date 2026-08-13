using UnityEngine;

public class FloatUpAndDown : MonoBehaviour
{
    float startYPosition;

    float timer = 0f;

    public float scaleFactor = 1f;

    public float moveSpeed =1f;

    void Awake(){
        startYPosition = transform.position.y;

    }


    void Update()
    {
        //Fades Image
        timer += Time.deltaTime;

        if(timer >= 2 / moveSpeed){
            timer = 0f;
        }

        float newYPosition = startYPosition + (scaleFactor * Mathf.Cos(Mathf.PI * timer * moveSpeed));

        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        // if(fadingTimer > (5f * (2f))){
        //     fadingTimer = 0f;
        // }

        // percentageFaded = originalFadeAmount * ( ( (Mathf.Cos((fadingTimer * Mathf.PI) + offsetFade)) * 0.5f ) + 0.5f );

        // percentageFaded = lowerCap + ((upperCap - lowerCap) * percentageFaded);

        // myImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, percentageFaded);


    }
}
