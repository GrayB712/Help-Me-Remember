using UnityEngine;
using System;

public class SoundEffectManager : MonoBehaviour
{
    public AudioSourceManager audioSourceManager;

    public TextAsset AudioResourceMap;

    private SoundEffect[] soundEffects;

    public void Start(){
        //Debug.Log("On enable is called");
        LoadAudioResourceMap();
    }

    private void LoadAudioResourceMap(){
        try{
            
            //Debug.Log("Loading audio resource map");

            //Gets raw data from audio resource map as string
            string rawMapData  = AudioResourceMap.text;

            //Splits data into rows, since each row has the info for a single audio clip
            string[] dataRows = rawMapData.Split('\n');

            soundEffects = new SoundEffect[dataRows.Length];

            //Loads each row of data into a sound effect object
            for(int i = 0; i < dataRows.Length; i++){
                string[] data = dataRows[i].Split(',');
                
                if(data.Length >= 2){
                    
                    //Sound effect file comes first, event comes second
                    soundEffects[i] = new SoundEffect(data[0], data[1]);
                } else{
                    Debug.LogError("Incorrectly formatted sound effect line, you bozo! There might be a blank line at the end of the Audio Resource Map. Did you press enter too many times!?!?!.+!!");
                }
                
            }

            AddListenersToPlaySoundEffects();

        } catch {
            Debug.LogError("Failed to load Audio Resource Map");
        }
    }

    private void AddListenersToPlaySoundEffects(){
        foreach(SoundEffect soundEffect in soundEffects){
            if(soundEffect.eventToPlay != null && GameEventManager.current != null){
                //Debug.Log("Added listener to " + soundEffect.eventToPlay);
                GameEventManager.current.GetEvent(soundEffect.eventToPlay).AddListener(soundEffect.PlaySound);
            } else {
                Debug.Log("No event for this sound effect!");
            }
        }
    }

    


}

public class SoundEffect{
    public AudioClip soundFile;
    public GameEventManager.GameEvent eventToPlay;

    // Loads the input strings into the sound effect parameters
    public SoundEffect(string _soundFile, string _eventToPlay){

        //Loads the matching event from the input string
        if(GameEventManager.current != null){
            GameEventManager.GameEvent eventAsEnum;
            if(Enum.TryParse<GameEventManager.GameEvent>(_eventToPlay, out eventAsEnum)){
                eventToPlay = eventAsEnum;
            } else {
                Debug.Log("\"" + eventToPlay + "\"" + "ain't a valid game event! Make sure you typed it into the audio resource map file correctly.");
            }

        }

        //Note: "Audio/" is the parent folder of all audio assets
        string audioClipPath = "Audio/AudioFiles/" + _soundFile;

        //Tries to load the audio clip using the provided path
        try{
            soundFile = Resources.Load<AudioClip>(audioClipPath);
        } catch{
            Debug.LogError("Failure getting soundID at path " + audioClipPath);
        }

        
    }

    public SoundEffect(AudioClip _soundFile, GameEventManager.GameEvent _eventToPlay){
        soundFile = _soundFile;
        eventToPlay = _eventToPlay;
    }

    public void PlaySound(){

        Debug.Log("playing sound");

        if(AudioSourceManager.current != null){
            AudioSourceManager.current.PlaySound(soundFile);
        } else {
            Debug.LogError("HELP!! I CAN'T FIND THE AUDIO SOURCE MANAGER!!!!!!!");
        }
        
    }


}