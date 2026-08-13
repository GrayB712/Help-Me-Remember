using UnityEngine;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{
    public static WorldSwitcher current;

    public GameObject[] worlds;

    public int currentWorld;

    public bool freezeInput;

    public float timeToFade = .5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneTransitionAnimator.current.FadeBlackOut((1f/3f) * timeToFade);
        if(current == null){
            current = this;
            currentWorld = 0;
        }
    }

    // 0 = Bed World
    // 1 = Diary World
    // 2 = Radio World
    // 3 = Photo World
    // 4 = Nursing Home
    public void SwitchToWorld(int worldID){

        //Prevents buttons from being pressed during transition
        freezeInput = true;

        StartCoroutine(WaitToSwitchWorlds(worldID));

        GameEventManager.current.GetEvent(GameEventManager.GameEvent.WorldBeganSwitching).Invoke();

    }

    private IEnumerator WaitToSwitchWorlds(int worldID){

        //Tells animator to fade out scene
        SceneTransitionAnimator.current.FadeBlackIn((1f/3f) * timeToFade);

        //Waits for time to fade out scene
        yield return new WaitForSeconds((1f/3f) * timeToFade);

        //Turns off old world
        foreach(GameObject world in worlds){
            world.SetActive(false);
        }

        currentWorld = worldID;

        //Activates new world
        worlds[worldID].SetActive(true);

        //Tells new world it's been activated
        WorldScript newWorld = worlds[worldID].GetComponent<WorldScript>();
        if(newWorld != null){
            newWorld.ThisWorldJustActivated();
        }

        //Leaves world dark for a pause
        yield return new WaitForSeconds((1f/3f) * timeToFade);

        //Tells animator to fade the scene back
        SceneTransitionAnimator.current.FadeBlackOut((1f/3f) * timeToFade);

        //Waits for fade to finsish before unfreezing input
        yield return new WaitForSeconds((1f/3f) * timeToFade);
        freezeInput = false;

    }
}
