using UnityEngine;
using System.Collections;

public class AudioSourceManager : MonoBehaviour
{
    public static AudioSourceManager current;
    int maxAudioSources = 50;

    private AudioSource[] audioSources;

    // Creates 10 audio sources. Why 10??! I don't know!!!! Stop questioning me!1!!
    public void OnEnable(){

        if(current == null){
            current = this;
        } else {
            Destroy(this);
        }

        int startingNumberOfAudioSources = 10;
        audioSources = new AudioSource[startingNumberOfAudioSources];

        for(int i = 0; i < startingNumberOfAudioSources; i++){
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
        
    }

    //Plays input sound effect
    public void PlaySound(AudioClip soundEffect){

        //Gets the first unoccupied audio source
        AudioSource audioSource = GetAudioSource();


        if(audioSource != null){

            //Plays sound effect through audio source and clears the source when it's done.
            audioSource.clip = soundEffect;
            Debug.Log("Playing one shot");
            audioSource.PlayOneShot(soundEffect);
            StartCoroutine(ClearAudioSource(audioSource, (float)soundEffect.length)); // Waits for length of sound effect to clear source

        } else {
            Debug.Log("Ain't enough audio sources to yodel out yer audio clip! Try increasing 'maxAudioSources'.");
        }

    }

    // Returns the first unoccupied audio source
    private AudioSource GetAudioSource(){
        for(int i = 0; i < audioSources.Length; i++){

            if(audioSources[i].clip == null){
                return audioSources[i];
            }

        }


        // If none of the audio sources are unoccupied, double the number of audio sources if that
        // won't put it over the max number of audio sources.
        if((audioSources.Length * 2) <= maxAudioSources){

            // Returns first newly created audio source
            int previousNumOfSources = audioSources.Length;
            DoubleAudioSources();
            return audioSources[previousNumOfSources];

        } else {
            Debug.LogError("Audio sources maxed out!!!");
            return null;
        }
        

    }

    // Waits 'timeToWait' seconds before clearing the clip from the input audioSource
    private IEnumerator ClearAudioSource(AudioSource audioSource, float timeToWait){

        yield return new WaitForSeconds(timeToWait);

        audioSource.clip = null;
        
    }

    // Doubles the number of audio sources on this object
    private void DoubleAudioSources(){

        // Stores the number of audio sources that are in the old and new arrays
        int oldNumOfSources = audioSources.Length;
        int newNumOfSources = audioSources.Length * 2;

        // Intimidates developer if they try to create too many audio sources
        if(newNumOfSources > maxAudioSources){
            Debug.LogError("Trying to create more audio sources than max. Well too bad! YOU GOT DENIED!!!! MWA HA HAAA HAAaAAA!!!!!!!");
            return;
        }

        //Creates a new array, twice as big as the old array
        AudioSource[] newArray = new AudioSource[newNumOfSources];

        // Copies all the elements from the old array into the new one
        for(int i = 0; i < oldNumOfSources; i++){
            newArray[i] = audioSources[i];
        }

        // Fills the rest of the new array with new audio sources
        for(int i = oldNumOfSources; i < newNumOfSources; i++){
            newArray[i] = gameObject.AddComponent<AudioSource>();
        }

        // Switches the old array and the new array
        audioSources = newArray;

    }

}
