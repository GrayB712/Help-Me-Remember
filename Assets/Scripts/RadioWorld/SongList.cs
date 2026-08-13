using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SongList : MonoBehaviour
{
    public static SongList current;

    void Awake(){
        if(current == null){
            current = this;
        }
    }

    Song[] allSongs = new Song[] {
        //new Song("Ring of Fire", "Cash", "Johnny", ""),
        new Song("Sweater Song", "Weezer", "", ""),
        new Song("Hound Dog", "Presley", "Elvis", ""),
        new Song("Ain't No Woman", "Four Tops", "The", ""),
        new Song("All the Way", "Sinatra", "Frank", ""),
        new Song("Alone and Forsaken", "Williams", "Hank", ""),
        new Song("Always on My Mind", "Nelson", "Willie", ""),
        new Song("American Tune", "Simon", "Paul", ""),
        new Song("And So It Goes", "Joel", "Billy", ""),
        new Song("At Last", "James", "Etta", ""),
        new Song("Blackbird", "Beatles", "The", ""),
        new Song("Bleeker Street", "Simon & Garfunkel", "", ""),
        new Song("Blowin in the Wind", "Dylan", "Bob", ""),
        new Song("Blue Suede Shoes", "Perkins", "Carl", ""),
        new Song("Blueberry Hill", "Domino", "Fats", ""),
        new Song("Blues Run the Game", "Frank", "Jackson", ""),
        new Song("Bohemian Rhapsodie", "Queen", "", ""),
        new Song("Born to Love", "Holiday", "Billie", ""),
        new Song("Both Sides Now", "Mitchell", "Joni", ""),
        new Song("Boulder to Birmingham", "Harris", "Emmylou", ""),
        new Song("Button up Your Overcoat", "Haymes", "Dick", ""),
        new Song("Cactus Tree", "Mitchell", "Joni", ""),
        new Song("California Dreamin", "Mamas & the Papas", "The", ""),
        new Song("Carolina on My Mind", "Taylor", "James", ""),
        new Song("A Case of You", "Mitchell", "Joni", ""),
        new Song("Chain of Fools", "Franklin", "Aretha", ""),
        new Song("Chelsea Morning", "Mitchell", "Joni", ""),
        new Song("Crazy", "Cline", "Patsy", ""),
        new Song("Daydream Believer", "Monkees", "The", ""),
        new Song("Dear Prudence", "Beatles", "The", ""),
        new Song("Desolation Row", "Dylan", "Bob", ""),
        new Song("Different Drum", "Ronstadt", "Linda", ""),
        new Song("Don't Be Cruel", "Presley", "Elvis", ""),
        new Song("Drive My Car", "Beatles", "The", ""),
        new Song("Dust in the Wind", "Kansas", "", ""),
        new Song("Early Mornin' Rain", "Peter Paul & Mary", "", ""),
        new Song("Eleanor Rigby", "Beatles", "The", ""),
        new Song("Eight Days a Week", "Beatles", "The", ""),
        new Song(" and Son", "Stevens", "Cat", ""),
        new Song(" Good", "Simone", "Nina", ""),
        new Song("Fever", "Lee", "Peggy", ""),
        new Song("Fire and Rain", "Taylor", "James", ""),
        new Song("Friday I'm in Love", "Cure", "The", ""),
        new Song("Goodbye Yellow Brick Road", "John", "Elton", ""),
        new Song("Gimme Shelter", "Rolling Stones", "The", ""),
        new Song("Handle With Care", "Traveling Wilburys", "", ""),
        new Song("Harvest Moon", "Young", "Neil", ""),
        new Song("Helplessly Hoping", "Crosby Stills & Nash", "", ""),
        new Song("Here Comes the Sun", "Beatles", "The", ""),
        new Song("Home Again", "King", "Carole", ""),
        new Song("Homeward Bound", "Simon & Garfunkel", "", ""),
        new Song("I Got a Name", "Croce", "Jim", ""),
        new Song("I Love You Baby", "Valli", "Frankie", ""),
        new Song("I Started a Joke", "Bee Gees", "The", ""),
        new Song("I Walk the Line", "Cash", "Johnny", ""),
        new Song("I Will Survive", "Gaynor", "Gloria", ""),
        new Song("I Will Wait", "Mumford & Sons", "", ""),
        new Song("I'll Follow the Sun", "Beatles", "The", ""),
        new Song("I'm a Believer", "Monkees", "The", ""),
        new Song("I'm Gonna Be", "Proclaimers", "The", ""),
        new Song("If I Had a Boat", "Lovett", "Lyle", ""),
        new Song("Immigrant Song", "Led Zeppelin", "", ""),
        new Song("Into the Mystic", "Morrison", "Van", ""),
        new Song("Just Like a Woman", "Dylan", "Bob", ""),
        new Song("Just My Imagination", "Temptations", "The", ""),
        new Song("Kathy's Song", "Simon & Garfunkel", "", ""),
        new Song("Kiss Me", "Sixpence None the Richer", "", ""),
        new Song("La Bamba", "Valens", "Ritchie", ""),
        new Song("Leaving on a Jet Plane", "Denver", "John", ""),
        new Song("Lemon Tree", "Peter Paul & Mary", "", ""),
        new Song("Let It Be", "Beatles", "The", ""),
        new Song("Let It Be Me", "Everly Brothers", "The", ""),
        new Song("Like a Rolling Stone", "Dylan", "Bob", ""),
        new Song("Little Green", "Mitchell", "Joni", ""),
        new Song("Long Black Veil", "Band", "The", ""),
        new Song("Long Long Time", "Ronstadt", "Linda", ""),
        new Song("Long Tall Sally", "Little Richard", "", ""),
        new Song("Love Child", "Supremes", "The", ""),
        new Song("Me and Bobby McGee", "Joplin", "Janis", ""),
        new Song("Mercy Mercy Me", "Gaye", "Marvin", ""),
        new Song("Midnight Train to Georgia", "Knight", "Gladys", ""),
        new Song("Miles from Nowhere", "Stevens", "Cat", ""),
        new Song("Monday Monday", "Mamas & the Papas", "The", ""),
        new Song("More Than a Feeling", "Boston", "", ""),
        new Song("Mr. Tambourine Man", "Byrds", "The", ""),
        new Song("My Funny Valentine", "Baker", "Chet", ""),
        new Song("My Girl", "Temptations", "The", ""),
        new Song("Night and Day", "Fitzgerald", "Ella", ""),
        new Song("North Country Blues", "Dylan", "Bob", ""),
        new Song("Nowhere Man", "Beatles", "The", ""),
        new Song("Our House", "Crosby Stills & Nash", "", ""),
        new Song("Peace of Mind", "Boston", "", ""),
        new Song("Piano Man", "Joel", "Billy", ""),
        new Song("Piece of My Heart", "Joplin", "Janis", ""),
        new Song("Purple Heather", "Morrison", "Van", ""),
        new Song("Queen Jane Approximately", "Dylan", "Bob", ""),
        new Song("Rain", "Beatles", "The", ""),
        new Song("The Rain Song", "Led Zeppelin", "", ""),
        new Song("Ramblin Man", "Williams", "Hank", ""),
        new Song("Red Red Wine", "Diamond", "Neil", ""),
        new Song("Reflections", "Supremes", "The", ""),
        new Song("Ride Away", "Orbison", "Roy", ""),
        new Song("Rocket Man", "John", "Elton", ""),
        new Song("A Rose for Emily", "Zombies", "The", ""),
        new Song("Ruby Tuesday", "Rolling Stones", "The", ""),
        new Song("Scarborough Fair", "Simon & Garfunkel", "", ""),
        new Song("She", "Monkees", "The", ""),
        new Song("She's a Rainbow", "Rolling Stones", "The", ""),
        new Song("She's Got a Way", "Joel", "Billy", ""),
        new Song("She's Not There", "Zombies", "The", ""),
        new Song("Shelter from the Storm", "Dylan", "Bob", ""),
        new Song("Shiny Happy People", "R.E.M.", "", ""),
        new Song("So Far Away", "King", "Carole", ""),
        new Song("Solitary Man", "Diamond", "Neil", ""),
        new Song("Something", "Beatles", "The", ""),
        new Song("Son of a Preacher Man", "Springfield", "Dusty", ""),
        new Song("Songbird", "Fleetwood Mac", "", ""),
        new Song("Soul Man", "Sam & Dave", "", ""),
        new Song("The Sounds of Silence", "Simon & Garfunkel", "", ""),
        new Song("Stand", "R.E.M.", "", ""),
        new Song("Stay Young Go Dancing", "Death Cab for Cutie", "", ""),
        new Song("Stayin' Alive", "Bee Gees", "The", ""),
        new Song("Strange", "Cline", "Patsy", ""),
        new Song("Subterranean Homesick Blues", "Dylan", "Bob", ""),
        new Song("A Summer Song", "Chad & Jeremy", "", ""),
        new Song("Sunshine of Your Love", "Cream", "", ""),
        new Song("Sunshine on My Shoulders", "Denver", "Bob", ""),
        new Song("Sweet Caroline", "Diamond", "Neil", ""),
        new Song("Take Me Home Country Roads", "Denver", "John", ""),
        new Song("Take on Me", "A-Ha", "", ""),
        new Song("Take It with Me", "Waits", "Tom", ""),
        new Song("Taxman", "Beatles", "The", ""),
        new Song("Tell Her No", "Zombies", "The", ""),
        new Song("Tell Mama", "James", "Etta", ""),
        new Song("Thank You", "Led Zeppelin", "", ""),
        new Song("That Old Black Magic", "Prima", "Louis", ""),
        new Song("That'll Be the Day", "Holly", "Buddy", ""),
        new Song("There She Goes", "Boo Radleys", "The", ""),
        new Song("These Days", "Brown", "Jackson", ""),
        new Song("Think", "Franklin", "Aretha", ""),
        new Song("Three O'clock Blues", "King", "B.B.", ""),
        new Song("Ticket to Ride", "Beatles", "The", ""),
        new Song("Tin Angel", "Mitchell", "Joni", ""),
        new Song("Tiny Dancer", "John", "Elton", ""),
        new Song("Tired of Waiting for You", "Kinks", "The", ""),
        new Song("To Love Somebody", "Bee Gees", "The", ""),
        new Song("Tomorrow Is a Long Time", "Dylan", "Bob", ""),
        new Song("Trav'lin All Alone", "Holiday", "Billie", ""),
        new Song("Trouble", "Stevens", "Cat", ""),
        new Song("Tupelo Honey", "Morrison", "Van", ""),
        new Song("The Weight", "Band", "The", ""),
        new Song("Unforgettable", "Cole", "Nat King", ""),
        new Song("Vincent", "McLean", "Don", ""),
        new Song("Visions of Johanna", "Dylan", "Bob", ""),
        new Song("West End Blues", "Armstrong", "Louis", ""),
        new Song("What'd I Say", "Charles", "Ray", ""),
        new Song("What's Going On", "Gaye", "Marvin", ""),
        new Song("When Will I Be Loved", "Everly Brothers", "", ""),
        new Song("Whiter Shade of Pale", "Procol Harum", "", ""),
        //new Song("Who'll Stop the Rain", "Creedence Clearwater Revival", "", ""),
        new Song("Wild World", "Stevens", "Cat", ""),
        new Song("Yesterday", "Beatles", "The", ""),
        new Song("You Are a Tourist", "Death Cab for Cutie", "", ""),
        new Song("You Belong to Me", "Cline", "Patsy", ""),
        new Song("You Can Call Me Al", "Simon", "Paul", ""),
        new Song("You Can't Hurry Love", "Supremes", "The", ""),
        new Song("You Make Loving Fun", "Fleetwood Mac", "", ""),
        new Song("You Send Me", "Cooke", "Sam", ""),
        new Song("Your Song", "John", "Elton", ""),
    };

    

    public Song[] FindMatchingSongs(string searchQuery){

        List<Song> matchingSongs = new List<Song>();

        //Find songs with matching song names
        foreach(Song song in allSongs){
            if(song.songName.ToLower().StartsWith(searchQuery.ToLower())){
                matchingSongs.Add(song);
            }
        }

        //Finds songs with matching artist first names  
        foreach(Song song in allSongs){
            if(song.artistFirstName.ToLower().StartsWith(searchQuery.ToLower()) && !matchingSongs.Contains(song)){
                matchingSongs.Add(song);
            }
        }

        //Finds songs with matching artist last names  
        foreach(Song song in allSongs){
            if(song.artistLastName.ToLower().StartsWith(searchQuery.ToLower()) && !matchingSongs.Contains(song)){
                matchingSongs.Add(song);
            }
        }

        //Finds songs with matching full song names
        foreach(Song song in allSongs){
            if(song.fullSongName.ToLower().StartsWith(searchQuery.ToLower()) && !matchingSongs.Contains(song)){
                matchingSongs.Add(song);
            }
        }

        //Finds songs with matching full artist names
        foreach(Song song in allSongs){
            if(song.fullArtistName.ToLower().StartsWith(searchQuery.ToLower()) && !matchingSongs.Contains(song)){
                matchingSongs.Add(song);
            }

        }

        Song[] returnArray = new Song[6];
        for(int i = 0; i < returnArray.Length && i < matchingSongs.Count; i++){
            returnArray[i] = matchingSongs[i];
        }

        return returnArray;


    }
    



    

}

public class Song{
    public string songName;
    public string artistFirstName;
    public string artistLastName;
    public string songLyrics;
    public string fullSongName;
    public string fullArtistName;

    public Song(string _songName, string _artistLastName, string _artistFirstName, string _songLyrics){
        songName = _songName;
        artistFirstName = _artistFirstName;
        artistLastName = _artistLastName;
        songLyrics = _songLyrics;
        fullSongName = songName + " by " + artistFirstName + " " + artistLastName;
        fullArtistName = artistFirstName + " " + artistLastName;
    }
}
