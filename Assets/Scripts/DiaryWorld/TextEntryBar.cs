using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TextEntryBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public bool CallSearchFunctionOnInput = false;

    public int maxInputLength = 25;

    public TextMeshProUGUI entryTextObject;

    public string currentEntry = "";
    
    public GameObject playerPrompt;

    public GameObject MouseHoveringGraphic;

    public GameObject textBoxSelectedGraphic;

    public DisplaySearchResults searchResultDisplayer;

    public bool isSelected = false;

    private bool mouseIsOverMe = false;

    float cursorTimer = 0f;
    public float cursorBlinkTime = .2f;
    bool cursorIsOn = false;

    void Awake(){
        RunSearch();
    }

    bool backspaceAlreadyPressed = false;
    float timeBackspaceHeld = 0f;
    bool backspaceHeldDown = false;
    void Update(){
        
        if(Mouse.current.leftButton.wasPressedThisFrame && !mouseIsOverMe){
            isSelected = false;
            textBoxSelectedGraphic.SetActive(false);
            if(currentEntry == ""){
                playerPrompt.SetActive(true);
            }
        }

        if(isSelected){
            MouseHoveringGraphic.SetActive(false);
            cursorTimer += Time.deltaTime;
            if(cursorTimer > cursorBlinkTime){
                cursorTimer = 0f;
                if(cursorIsOn){
                    entryTextObject.text = currentEntry;
                } else{
                    entryTextObject.text = currentEntry + "|";
                }
                cursorIsOn = !cursorIsOn;

            }
        } else{
            entryTextObject.text = currentEntry;
        }

        if(Keyboard.current != null && Keyboard.current.backspaceKey.isPressed){
            if(isSelected && (!backspaceAlreadyPressed || backspaceHeldDown)){

                if(backspaceAlreadyPressed){
                    timeBackspaceHeld = .36f;
                }

                backspaceAlreadyPressed = true;

                PlayerTyped((char)8);

                backspaceHeldDown = false;
                
                


                //Debug.Log("Keyboard.current.backspaceKey.wasPressedThisFrame works");
            } else if(backspaceAlreadyPressed){
                timeBackspaceHeld += Time.deltaTime;
                Debug.Log("time held: " + timeBackspaceHeld);
                if(timeBackspaceHeld > .4f){
                    backspaceHeldDown = true;
                }
            }

        }

        if(Keyboard.current != null && Keyboard.current.backspaceKey.wasReleasedThisFrame){
            backspaceAlreadyPressed = false;
            backspaceHeldDown = false;
            timeBackspaceHeld = 0f;

        }

    }

    //Subscribes to keyboard entries
    private void OnEnable()
    {
        Keyboard.current.onTextInput += OnCharacterTyped;
    }
    private void OnDisable()
    {
        if (Keyboard.current != null) { Keyboard.current.onTextInput -= OnCharacterTyped;}
    }



    //Processes typing
    private void OnCharacterTyped(char character)
    {
        if(!isSelected){
            return;
        }

        if(!((int)character == 8)){
            PlayerTyped(character);
        }

        Debug.Log((int)character);

        
        //Whenever the player is typing, the cursor bar is on
        cursorTimer = 0f;
        cursorIsOn = true;
        entryTextObject.text = currentEntry + "|";
        

        
    }

    private void PlayerTyped(char character){

        cursorTimer = 0f;

        if((int)character >= 20 && (int)character <= 126){
            appendCharacterToEntry(char.ToUpper(character));
        } else if((int)character == 8){
            Debug.Log("Deleting Character");
            deleteLastCharacterFromEntry();
        }

        UpdateDisplayedText();

        if(CallSearchFunctionOnInput){
            RunSearch();
        }
    }

    private void RunSearch(){
        Song[] matchingSongs = SongList.current.FindMatchingSongs(currentEntry);
        if(searchResultDisplayer != null)
            searchResultDisplayer.DisplayResults(matchingSongs);
    }


    private void appendCharacterToEntry(char character){
        if(currentEntry.Length >= maxInputLength) return;
        currentEntry = currentEntry + character;
    }

    private void deleteLastCharacterFromEntry(){
        if(currentEntry.Length == 0) return;
        currentEntry = currentEntry.Remove(currentEntry.Length - 1);
    }

    private void UpdateDisplayedText(){
        entryTextObject.text = currentEntry;
        if(cursorIsOn){
            entryTextObject.text = currentEntry + "|";
        }
    }

    public void ResetInputText(){
        currentEntry = "";
        UpdateDisplayedText();
    }



    //Mouse Events
    public void OnPointerClick(PointerEventData eventData){
        isSelected = true;
        playerPrompt.SetActive(false);
        textBoxSelectedGraphic.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData){
        mouseIsOverMe = true;
        if(MouseHoveringGraphic != null){
            MouseHoveringGraphic.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        mouseIsOverMe = false;
        if(MouseHoveringGraphic != null){
            MouseHoveringGraphic.SetActive(false);
        }
    }

}
