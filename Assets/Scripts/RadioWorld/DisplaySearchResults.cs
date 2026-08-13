using UnityEngine;

public class DisplaySearchResults : MonoBehaviour
{

    public SongDisplayer[] songDisplayers;

    public void DisplayResults(Song[] searchResults){

        int numberOfSearchResults = 0;

        foreach(Song song in searchResults){
            if(song != null)
                numberOfSearchResults++;
        }

        foreach(SongDisplayer songDisplayer in songDisplayers){
            songDisplayer.gameObject.SetActive(false);
        }

        for(int i = 0; i < searchResults.Length && i < songDisplayers.Length; i++){
            if(searchResults[i] != null){
                songDisplayers[i].gameObject.SetActive(true);
                songDisplayers[i].DisplaySong(searchResults[i]);
            }
            
        }


    }
}
