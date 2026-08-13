using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager current;

    // private bool isDiaryWorldCompleted = false;
    // public bool IsDiaryWorldCompleted{
    //     get{
    //         return isDiaryWorldCompleted;
    //     }
    // }

    public bool diaryIsCompleted = false;
    public bool radioIsCompleted = false;
    public bool photographIsCompleted = false;

    public bool worldsAreCompleted = false;


    void Start(){
        if(current == null){
            current = this;
        }
    }

    public void DiaryWorldCompleted(){
        diaryIsCompleted = true;
        CheckForTotalCompletion();
    }

    public void RadioWorldCompleted(){
        radioIsCompleted = true;
        CheckForTotalCompletion();
    }

    public void PhotographWorldCompleted(){
        photographIsCompleted = true;
        CheckForTotalCompletion();
    }

    public void CheckForTotalCompletion(){
        if(diaryIsCompleted && radioIsCompleted && photographIsCompleted){
            worldsAreCompleted = true;
        }
    }


}
