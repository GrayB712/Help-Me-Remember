using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WatchKnobScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{

    public GameObject highlightedGraphic;

    public GameObject pushedInKnob;
    public GameObject pushedOutKnob;

    public LargePocketWatchScript watch;

    public int myKnobID = 0;

    public void OnPointerClick(PointerEventData eventData){
       watch.KnobPressed(myKnobID);
    }
    
    public void OnPointerEnter(PointerEventData eventData){
        //highlightedGraphic.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData){
        //highlightedGraphic.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData){
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.WatchButtonDown).Invoke();
        pushedInKnob.SetActive(true);
        pushedOutKnob.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData){
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.WatchButtonUp).Invoke();
        pushedInKnob.SetActive(false);
        pushedOutKnob.SetActive(true);
    }

}
