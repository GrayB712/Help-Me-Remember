using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject DialogueBackground;
    public TextMeshProUGUI DialogueTextBox;

    public GameObject MouseHoverGraphic;

    public DialoguePiece currentDialoguePiece = null;

    private int currentDialoguePage = 0;



    public void DisplayDialogue(DialoguePiece newDialogue){
        DialogueBackground.SetActive(true);
        currentDialoguePage = 0;
        currentDialoguePiece = newDialogue;
        DialogueTextBox.text = currentDialoguePiece.pages[currentDialoguePage];
    }

    public void NextDialoguePage(){

        GameEventManager.current.GetEvent(GameEventManager.GameEvent.DialogueBoxClicked).Invoke();

        currentDialoguePage++;

        if(currentDialoguePage >= currentDialoguePiece.pages.Length){
            DeactivateDialogueBox();
        } else{
            DialogueTextBox.text = currentDialoguePiece.pages[currentDialoguePage];
        }

    }

    public void DeactivateDialogueBox(){
        currentDialoguePiece = null;
        currentDialoguePage = 0;
        DialogueTextBox.text = "";
        DialogueBackground.SetActive(false);
    }



    public void OnPointerClick(PointerEventData eventData){
        NextDialoguePage();
    }



    
    public void OnPointerEnter(PointerEventData eventData){
        MouseHoverGraphic.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        MouseHoverGraphic.SetActive(false);
    }
}

public class DialoguePiece{
    public string[] pages;

    public DialoguePiece(string[] _pages){
        pages = _pages;
    }
}
