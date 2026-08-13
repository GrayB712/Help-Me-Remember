using UnityEngine;

public class LoadSongDialogue : MonoBehaviour
{
    public DialogueController dialogueBox;

    private string[] randomSongMemories = new string[] {
        "The static on the music track is distracting. The vinyl must have been more damaged than expected when I bought it.",
        "Rain is making pattering sounds on my umbrella overhead. The melody of a song comes from a nearby window.",
        "The vibrations from the song on the car's radio are coming through the steering wheel. It's a nice sensation. I think there's a siren somewhere in the distance.",
        "The music is pouring down from an overhead speaker in a department store as crowds of people bustle by on either side.",
        "Dan is humming along to a song from the record player. It's difficult to make out over the sound of the running sink, but knowing he's in a better mood is uplifting.",
        "Cheering and clapping is coming from the left and the right, aimed at the stage where the song is being played. Concerts are a bit louder than I expected.",
        "The gentle hum of the sewing machine under hand blends in with the crackling of the song coming from my handheld radio.",
        "A muffled song is coming through the thin walls of a hotel room. It is further muffled by a pillow.",
        "The song starts abruptly pouring out of the record player. It's so easy to accidentally place the needle in the wrong spot.",
        
    };

    private int currentSongMemory = 0;

    public void LoadDialogueForSong(Song song){
        if(song.songName.ToLower() == "she's got a way"){
            LoadStringIntoDialogueBox("Billy Joel comes on the car radio, and Melody starts singing along with him. Her voice is like hearing an angel sing, letting you forget everything that's troubling your mind for a little while.");
        } else if(song.songName.ToLower() == "that'll be the day"){
            LoadStringIntoDialogueBox("Buddy Holly is singing through the car radio. In the background, Dan's trying to simultaneously drive and explain how to open his watch to Melody, 'Here, you try it. Press the top button, then the second from the bottom, then the top one again.'");
        } else if(song.songName.ToLower() == "i walk the line"){
            LoadStringIntoDialogueBox("The record player is pumping out the Johnny Cash song louder than it's played anything before. Dancing feet are thumping the floor and two women are laughing. One shouts, 'This is the first time I've felt this happy since Christmas 2018!'");
        }else{

            currentSongMemory++;
            if(currentSongMemory >= randomSongMemories.Length){
                currentSongMemory = 0;
            }

            LoadStringIntoDialogueBox(randomSongMemories[currentSongMemory]);
            
        }
    }

    private void LoadStringIntoDialogueBox(string inputString){
        //Loads dialogue into DialoguePiece class
        string[] randomMemoryArray = new string[1];
        randomMemoryArray[0] = inputString;
        DialoguePiece randomMemory = new DialoguePiece(randomMemoryArray);

        dialogueBox.DisplayDialogue(randomMemory);
    }
}
