using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameEventManager : MonoBehaviour
{

    public static GameEventManager current;

    public UnityEvent ViewingScreenClosed { get; set; }

    public GameObject IntroWorld;
    public GameObject WorldSwitcher;

    public GameObject[] OtherWorlds;

    private UnityEvent[] GameEventsAsUnityEvents;
   
    void OnEnable()
    {
        if(current == null){
            current = this;
        }

        LoadEventsIntoUnityEvents();

        ViewingScreenClosed = new UnityEvent();


        // If the title screen comes first, then it loads the proper game state
        if(BootTracker.current != null){
            IntroWorld.SetActive(true);
            WorldSwitcher.SetActive(true);

            foreach(GameObject otherWorld in OtherWorlds){
                if(otherWorld != null){
                    otherWorld.SetActive(false);
                }
            }
        }


    
        
    }



    public enum GameEvent{
        WorldBeganSwitching,
        ButtonPressedDown,
        ButtonReleased,
        RadioStartedPlaying,
        BeginDiaryPageTurn,
        WatchButtonDown,
        WatchButtonUp,
        BeginOpenViewingScreen,
        BeginCloseViewingScreen,
        DialogueBoxClicked,
        RememberedSomething,
        
    }

    public UnityEvent GetEvent(GameEvent eventName){

        int eventIndex = (int)eventName;
        
        if(eventIndex >= 0 && eventIndex < GameEventsAsUnityEvents.Length){
            return GameEventsAsUnityEvents[eventIndex];
        } else {
            Debug.LogError("Can't find event!");
            return null;
        }

    }

    private void LoadEventsIntoUnityEvents(){
        GameEvent[] unloadedEvents = (GameEvent[])Enum.GetValues(typeof(GameEvent));
        GameEventsAsUnityEvents = new UnityEvent[unloadedEvents.Length];

        for(int i = 0; i < unloadedEvents.Length; i++){
            GameEventsAsUnityEvents[i] = new UnityEvent();
        }
    }
    
}
