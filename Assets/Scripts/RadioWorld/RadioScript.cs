using UnityEngine;
using TMPro;

public class RadioScript : MonoBehaviour
{
    public LoadSongDialogue textLoader;

    public RadioWinCondition radioWinCondition;
    public string songToWin = "";
    public static RadioScript current;

    public Song currentSongPlaying;

    public TextMeshProUGUI songTitleTextObject;
    public TextMeshProUGUI artistNameTextObject;

    void Start(){
        if(current == null){
            current = this;
        }
    }

    public void PlaySong(Song song){
        currentSongPlaying = song;
        songTitleTextObject.text = song.songName;
        artistNameTextObject.text = song.fullArtistName;

        textLoader.LoadDialogueForSong(song);

        //If they play the right song, they win the level
        if(song.songName.ToLower() == songToWin.ToLower()){
            radioWinCondition.FoundHerVoice();
        } else{ //Don't play radio sound if they play the winning song
            GameEventManager.current.GetEvent(GameEventManager.GameEvent.RadioStartedPlaying).Invoke();
        }

        
    }

}
