using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PersonPortal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject electricOutline;

    public int worldToSwitchToOnPress = 0;

    public bool mouseIsOverMe = false;

    void Update(){

        if(mouseIsOverMe && Mouse.current.leftButton.wasPressedThisFrame && (WorldSwitcher.current == null || !WorldSwitcher.current.freezeInput)){
            mouseIsOverMe = false;
            if(WorldSwitcher.current != null)
                WorldSwitcher.current.SwitchToWorld(worldToSwitchToOnPress);
        }

    }


    public void OnPointerEnter(PointerEventData eventData){
        mouseIsOverMe = true;
        electricOutline.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        mouseIsOverMe = false;
        electricOutline.SetActive(false);
    }

}
