using UnityEngine;

public class SceneTransitionAnimator : MonoBehaviour
{
    public static SceneTransitionAnimator current;

    public FadeSpriteToOpacity blackScreen;

    void Awake(){
        if(current == null){
            current = this;
        }
        blackScreen = GetComponent<FadeSpriteToOpacity>();
        

    }

    public void FadeBlackIn(float timeToFade){
        blackScreen.FadeToOpacity(1f, timeToFade);
    }

    public void FadeBlackOut(float timeToFade){
        blackScreen.FadeToOpacity(0f, timeToFade);
    }
}
