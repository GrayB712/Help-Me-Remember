using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewingScreen : MonoBehaviour
{
    public static ViewingScreen current;

    public GameObject ExitButton;

    public GameObject AllViewingItemsContainer;

    public FadeSpriteToOpacity darkBackground;

    public float timeToFadeScreenIn = .6f;

    public float darkBackgroundMaxOpacity = .97f;

    public bool isViewingItem = false;

    void Awake(){
        if(current == null){
            current = this;
        }
    }



    // Turning the screen on

    public void TurnOnViewingScreen(){
        isViewingItem = true;
        darkBackground.gameObject.SetActive(true);
        darkBackground.FadeToOpacity(darkBackgroundMaxOpacity, timeToFadeScreenIn);
        StartCoroutine(WaitToFinishFadingIn());
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.BeginOpenViewingScreen).Invoke();
    }

    private IEnumerator WaitToFinishFadingIn(){
        yield return new WaitForSeconds(timeToFadeScreenIn);
        ViewingScreenFinishedFadingIn();
    }
    private void ViewingScreenFinishedFadingIn(){
        ExitButton.SetActive(true);
        AllViewingItemsContainer.SetActive(true);
    }



    //Turning the screen off

    public void TurnOffViewingScreen(){
        
        darkBackground.FadeToOpacity(0f, timeToFadeScreenIn);
        AllViewingItemsContainer.SetActive(false);
        
        GameEventManager.current.ViewingScreenClosed.Invoke();

        StartCoroutine(WaitToFinishFadingOut());

        GameEventManager.current.GetEvent(GameEventManager.GameEvent.BeginCloseViewingScreen).Invoke();
    }

    private IEnumerator WaitToFinishFadingOut(){
        yield return new WaitForSeconds(timeToFadeScreenIn);
        ViewingScreenFinishedFadingOut();
        isViewingItem = false;
    }
    private void ViewingScreenFinishedFadingOut(){
        darkBackground.gameObject.SetActive(false);
    }

}
