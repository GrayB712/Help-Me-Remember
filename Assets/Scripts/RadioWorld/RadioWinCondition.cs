using UnityEngine;

public class RadioWinCondition : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject normalScreen;

    public void FoundHerVoice(){
        winScreen.SetActive(true);
        normalScreen.SetActive(false);
        GameStateManager.current.RadioWorldCompleted();
        GameEventManager.current.GetEvent(GameEventManager.GameEvent.RememberedSomething).Invoke();
    }
}
