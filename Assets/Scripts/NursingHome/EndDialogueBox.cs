using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EndDialogueBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public GameObject MouseHoverGraphic;

    public float timeBetweenCaptions = .15f;

    private int currentCaption = 0;

    public GameObject captionObject;

    public TextMeshProUGUI captionTextObject;
    public TextMeshProUGUI speakerTextObject;

    //public GameObject VeryEndText;

    public string[] captions = new string[]{
        "I still can't believe it progressed this quickly.",
        "It was only a few month ago that she was living by herself.",
        "It's so messed up that for the last few minutes we have with Mom, she can't even recognize us.",
        "Yeah... I always bring her diary when she's sick. It's the first time she can't write in it.",
        "I wish there was someone I could be mad at for this. It's just she hasn't even been able to remember my name for...",
        "Hang on. I think she's waking up \n Mom!",
        "Melody... it's good... to hear your voice",
        "She remembers",
        "I can't forget that easily... Timothy... Not completely",
        "[Hugs Mom] I love you.",
        "Jordan... I love you too...",
        "Here at the end... I'm glad I can remember."
    };

    public string[] speakers = new string[] {
        "Timothy",
        "Melody",
        "Jordan",
        "Melody",
        "Timothy",
        "Melody",
        "Mom",
        "Timothy",
        "Mom",
        "Jordan",
        "Mom"
    };

    void Start(){
        BeginDialogue();
    }

    public void BeginDialogue(){
        captionTextObject.text = captions[0];
        speakerTextObject.text = speakers[0];
        captionObject.SetActive(true);
    }
    
    private void NextCaption(){

        currentCaption++;
        if(currentCaption >= captions.Length){
            CaptionsOver();
            return;
        }

        captionTextObject.gameObject.SetActive(false);

        captionTextObject.text = captions[currentCaption];
        speakerTextObject.text = speakers[currentCaption];

        StartCoroutine(DelayedUpdateCaption());


    }

    //If this is the dialogue box at the beginning, it goes to the first scene at the end.
    private void CaptionsOver(){
        if(GetComponent<IntroLoader>() != null){
            captionObject.SetActive(false);
            WorldSwitcher.current.SwitchToWorld(0);
        } else{ //otherwise, fades black
            SceneTransitionAnimator.current.FadeBlackIn(.7f);
        }
    }


    private IEnumerator DelayedUpdateCaption(){

        //Waits to update the caption
        yield return new WaitForSeconds(timeBetweenCaptions);

        captionTextObject.gameObject.SetActive(true);

        captionObject.SetActive(true);

    }

    public void OnPointerEnter(PointerEventData eventData){
        MouseHoverGraphic.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData){
        MouseHoverGraphic.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData){
        NextCaption();
    }

}
