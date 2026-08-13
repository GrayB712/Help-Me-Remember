using UnityEngine;

public class PhotoWinCondition : MonoBehaviour
{
    public GameObject normalScreen;
    public GameObject winScreen;

    public void FoundHerFace(){
        normalScreen.SetActive(false);
        winScreen.SetActive(true);
        GameStateManager.current.PhotographWorldCompleted();
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.RememberedSomething).Invoke();
    }
}
