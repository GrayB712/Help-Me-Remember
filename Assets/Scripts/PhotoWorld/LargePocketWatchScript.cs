using UnityEngine;

public class LargePocketWatchScript : MonoBehaviour
{
    public GameObject closedGraphic;
    public GameObject openGraphic;

    public PhotoWinCondition photoWinCondition;

    public int[] knobCombo = new int[] {1, 3, 1};

    public int[] lastThreeKnobsPressed = new int[] {0, 0, 0};

    private int currentStepOfCombo = 0;

    public void ResetButtons(){
        lastThreeKnobsPressed = new int[] {0, 0, 0};
    }

    public void KnobPressed(int knobID){

        AddKnobPress(knobID);

        if(lastThreeKnobsPressed[0] == knobCombo[0] && lastThreeKnobsPressed[1] == knobCombo[1] && lastThreeKnobsPressed[2] == knobCombo[2]){
            OpenWatch();
        }


        // if(knobID == knobCombo[currentStepOfCombo]){
        //     currentStepOfCombo++;

        //     if(currentStepOfCombo >= knobCombo.Length){
        //         OpenWatch();
        //     }

        // } else{
        //     currentStepOfCombo = 0;
        // }
    }

    private void AddKnobPress(int KnobID){
        lastThreeKnobsPressed[2] = lastThreeKnobsPressed[1];
        lastThreeKnobsPressed[1] = lastThreeKnobsPressed[0]; 
        lastThreeKnobsPressed[0] = KnobID;
    }

    //Called to open the watch
    private void OpenWatch(){

        closedGraphic.SetActive(false);
        openGraphic.SetActive(true);

        photoWinCondition.FoundHerFace();

    }

}
