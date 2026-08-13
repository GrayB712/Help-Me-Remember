using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ViewingScreenX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ViewingScreen screen;

    public GameObject highlightedGraphic;

    
    public void OnPointerClick(PointerEventData eventData){
       screen.TurnOffViewingScreen();
    }
    
    public void OnPointerEnter(PointerEventData eventData){
        highlightedGraphic.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData){
        highlightedGraphic.SetActive(false);
    }

}
