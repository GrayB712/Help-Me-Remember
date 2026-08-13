using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SongDisplayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI songTextObject;

    public GameObject highlightedGraphic;

    public GameObject pressedDownGraphic;

    public Song myCurrentSong;

    private bool cursorIsOnMe = false;

    


    public void DisplaySong(Song song){
        myCurrentSong = song;
        songTextObject.text = song.fullSongName;
    }

    public void OnPointerClick(PointerEventData eventData){
        if(RadioScript.current != null){
            RadioScript.current.PlaySong(myCurrentSong);
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData){
        highlightedGraphic.SetActive(true);
        cursorIsOnMe = true;
        
    }

    public void OnPointerExit(PointerEventData eventData){
        highlightedGraphic.SetActive(false);
        pressedDownGraphic.SetActive(false);
        cursorIsOnMe = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        pressedDownGraphic.SetActive(true);
        highlightedGraphic.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData){
        pressedDownGraphic.SetActive(false);
        if(cursorIsOnMe){
            highlightedGraphic.SetActive(true);
        }
    }

    

}
