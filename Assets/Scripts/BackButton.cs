using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BackButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

    public int worldToGoToOnPress = 0;

    public GameObject hoveringOverButtonGraphic;

    public bool mouseIsOverMe = false;

    public bool isInPhotoWorld = false;

    void Awake(){
        mouseIsOverMe = false;
        
    }

    void Update(){
        // if(mouseIsOverMe && Mouse.current.leftButton.wasPressedThisFrame && !WorldSwitcher.current.freezeInput){
        //     WorldSwitcher.current.SwitchToWorld(worldToGoToOnPress);
        // }


    }

    public void OnPointerClick(PointerEventData eventData){

        if(isInPhotoWorld && ViewingScreen.current != null && ViewingScreen.current.isViewingItem){
            return;
        }

        if(WorldSwitcher.current.freezeInput){
            return;
        }
        //Debug.Log("CLICKERD!");



        if(!GameStateManager.current.worldsAreCompleted){ //goes to bed world
            WorldSwitcher.current.SwitchToWorld(worldToGoToOnPress);
        } else{ //goes to nursing home
            WorldSwitcher.current.SwitchToWorld(4);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData){
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.ButtonPressedDown).Invoke();
    }

    public void OnPointerUp(PointerEventData eventData){
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.ButtonReleased).Invoke();
    }
    
    public void OnPointerEnter(PointerEventData eventData){

        if(isInPhotoWorld && ViewingScreen.current != null && ViewingScreen.current.isViewingItem){
            return;
        }

        mouseIsOverMe = true;
        hoveringOverButtonGraphic.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData){
        mouseIsOverMe = false;
        hoveringOverButtonGraphic.SetActive(false);
    }

}
