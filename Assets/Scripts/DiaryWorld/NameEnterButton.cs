using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class NameEnterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public string correctName = "Timothy";
    public GameObject searchBar;
    public GameObject winScreen;
    public TextEntryBar inputBar;

    public ShakeGraphic searchTextShaker;

    public GameObject highlightedGraphic;

    private bool enterKeyAlreadyPressed = false;

    public float wrongEntryShakeTime = .3f;

    void Update(){

        // Submits text entry when enter key is pressed on keyboard
        if(Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame){
            if(!enterKeyAlreadyPressed && inputBar.isSelected){
                enterKeyAlreadyPressed = true;
                CheckTextEntry();
            }
        }

        // Enter key is released
        if(Keyboard.current != null && Keyboard.current.enterKey.wasReleasedThisFrame){
            enterKeyAlreadyPressed = false;
        }

    }


    public void OnPointerClick(PointerEventData eventData){
        CheckTextEntry();
    }

    private void CheckTextEntry(){
        if(inputBar.currentEntry == correctName.ToUpper()){
            CorrectNameEntered();
        } else{
            WrongNameEntered();
        }
    }

    private void CorrectNameEntered(){
        winScreen.SetActive(true);
        searchBar.SetActive(false);
        GameStateManager.current.DiaryWorldCompleted();
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.RememberedSomething).Invoke();
    }

    private void WrongNameEntered(){
        if(searchTextShaker != null){
            searchTextShaker.ShakeItUp();
            StartCoroutine(WaitToFinishShakingEntry());
        } else{
            Debug.LogError("Diary search text is null. That means I can't shake it! I wanna shake it!!!!!");
        }
    }

    private IEnumerator WaitToFinishShakingEntry(){

        yield return new WaitForSeconds(wrongEntryShakeTime);

        inputBar.ResetInputText();

    }



    
    public void OnPointerEnter(PointerEventData eventData){
        highlightedGraphic.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        highlightedGraphic.SetActive(false);
    }

}
