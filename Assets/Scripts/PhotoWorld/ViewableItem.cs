using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


// MUST ATTATCH A 2D COLLIDER TO OBJECT FOR THIS TO WORK

public class ViewableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject mouseHoveringGraphic;

    public GameObject pressedDownGraphic;

    public GameObject MyItemUpClose;

    private bool hasAlreadyViewedItem = false;

    public bool isInteractable {
        get{
            if(ViewingScreen.current != null){
                return !ViewingScreen.current.isViewingItem;
            } else{
                return true;
            }
        }
    }

    // public void OnEnable(){
    //     GameEventManager.current.ViewingScreenClosed.AddListener(ClosedViewingScreen);
    // }


    public void ViewMyItem(){

        if(!hasAlreadyViewedItem){
            hasAlreadyViewedItem = true;
            GameEventManager.current.ViewingScreenClosed.AddListener(ClosedViewingScreen);
        }

        

        MyItemUpClose.SetActive(true);

        if(MyItemUpClose.GetComponent<LargePocketWatchScript>() != null){
            MyItemUpClose.GetComponent<LargePocketWatchScript>().ResetButtons();
        }

        if(ViewingScreen.current != null){
            ViewingScreen.current.TurnOnViewingScreen();
        }
        
    }

    private void ClosedViewingScreen(){
        MyItemUpClose.SetActive(false);
    }



    public void OnPointerClick(PointerEventData eventData){
        if(!isInteractable) return;

        ViewMyItem();
    }



    
    public void OnPointerEnter(PointerEventData eventData){
        if(!isInteractable) return;

        mouseHoveringGraphic.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData){
        

        mouseHoveringGraphic.SetActive(false);
        pressedDownGraphic.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData){
        if(!isInteractable) return;

        pressedDownGraphic.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData){
        pressedDownGraphic.SetActive(false);
    }
}
