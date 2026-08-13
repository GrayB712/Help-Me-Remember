using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ArrowButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public NumberSelector numberSelector;

    public bool isUpArrow = true;



    public GameObject highlightedGraphic;
    public GameObject pressedDownGraphic;



    void Awake(){
        highlightedGraphic.SetActive(false);
        pressedDownGraphic.SetActive(false);
    }



    public void OnPointerClick(PointerEventData eventData){
       if(isUpArrow){
            numberSelector.UpArrowClicked();
       } else{
        numberSelector.DownArrowClicked();
       }
    }



    
    public void OnPointerEnter(PointerEventData eventData){
        highlightedGraphic.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData){
        highlightedGraphic.SetActive(false);
        pressedDownGraphic.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData){
        pressedDownGraphic.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData){
        pressedDownGraphic.SetActive(false);
    }

}
