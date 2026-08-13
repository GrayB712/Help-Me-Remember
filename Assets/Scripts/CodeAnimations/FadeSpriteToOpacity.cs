using UnityEngine;

public class FadeSpriteToOpacity : MonoBehaviour
{
    public SpriteRenderer myImage;

    float currentTime = 0f;
    float totalTime;

    Color startColor;

    float currentOpacity;
    float targetOpacity;
    float startOpacity;

    bool isFading = false;
    

    void Start(){

        myImage.gameObject.SetActive(true);
        startColor = myImage.color;
        currentOpacity = startColor.a;
        
        
    }

    public void FadeToOpacity(float _targetOpacity, float timeToFade){
        startOpacity = currentOpacity;
        targetOpacity = _targetOpacity;

        currentTime = 0f;
        totalTime = timeToFade;

        isFading = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(!isFading) return;


        currentTime += Time.deltaTime;

        if(currentTime > totalTime){ //Runs when fully faded to target

            isFading = false;
            SetOpacity(targetOpacity);
            currentOpacity = targetOpacity;
            currentTime = 0f;

        } else { // Currently Fading To target

            float newOpacity = startOpacity + ((currentTime / totalTime) * ( targetOpacity - startOpacity ));
            SetOpacity(newOpacity);

        }

        
    }

    private void SetOpacity(float opacityToSet){
        myImage.color = new Color(startColor.r, startColor.g, startColor.b, opacityToSet);
    }
}
