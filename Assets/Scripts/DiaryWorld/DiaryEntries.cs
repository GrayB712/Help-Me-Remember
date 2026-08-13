using UnityEngine;

public class DiaryEntries : MonoBehaviour
{
    public DiaryEntry[] allEntries = new DiaryEntry[] {

        new DiaryEntry(9,4,1975,"Little Melody got me a beautiful new diary. Unfortunately, I doubt I'll remember to write in it very often unless she reminds me."),
        new DiaryEntry(9,5,1975,"Refilled the bird feeders. Spotted several blackbirds, but no robins."),
        new DiaryEntry(9,6,1975,"Garden looks terrible, but it\'s too hot to go out & weed. Plenty of fresh basil though. Making pesto tomorrow."),
        new DiaryEntry(9,8,1975,"Went to the beach with the girls from work yesterday. Walked out on the pier (we hate sand). Beautiful sunset!"),
        new DiaryEntry(8,15,1990,"Jordan's officially moved in at college now. Dan's taking it pretty hard with her being the last one to move out. He doesn't show it, but I noticed he's started carrying around her picture in that new watch he got last week."),
        new DiaryEntry(8,13,1990,"Did some packing for Jordan's big move. And dog escaped AGAIN. Son found her two blocks away. He’ll fix the gate latch for me."),
        //new DiaryEntry(8,13,1990,"Did some packing for Jordan's big move. And dog escaped AGAIN. Son found her two blocks away. He’ll fix the gate latch for me."),
        new DiaryEntry(8,9,1990,"Went to the mall today. Dan got a new watch that he can put things inside. On the way back, I found a radio station playing some Buddy Holly. Reception was weak, but we turned up the volume, rolled the windows down & sang along. Hot and sweaty, but fun!"),
        new DiaryEntry(12,25,1976, "Precious baby born today. Still recovering in hospital; Melody brought me my diary so I would 'have something to do'. I finally settled on naming him Timothy, after grandpa Timothy. I have a feeling he's going to go places. Timothy's name will be one to remember."),
        new DiaryEntry(12,25,2018, "Just finished Christmas dinner. Whole family was able to make it so they could see Dan one more time. Somehow, we didn't have time for presents today. Opening them tomorrow"),
        new DiaryEntry(12,26,2018, "Dan died today. I don't even know why I'm writing this. It was just so much sooner than we thought it would be. We both thought he'd still be around to finish the move together in April."),
        new DiaryEntry(4,12,2019, "Keeping the girls for Jordan while she’s out of town. Took them shopping first thing for breakfast foods. Lucky Charms and Pop Tarts, of course. No wonder they love coming to Grandma’s house."),
        new DiaryEntry(4,6,2019,"Still so much to pack for the move. I don't know how I'd do it without all of Melody's help."),
        new DiaryEntry(4,14,2019, "All three children plus their families surprised me for my birthday with Italian Cream cake – my favorite."),
        new DiaryEntry(4,18,2019, "Sorting through the last things for the move & trying to decide what to keep. I hate to leave, but the stairs and everything are too much for me now."),
        new DiaryEntry(4,23,2019, "Mostly finished move into apartments. Last set up is tomorrow"),
        new DiaryEntry(4,26,2019, "In hospital. Had fall on Wednesday. Melody brought me my diary. She's coming to get me tomorrow"),
        new DiaryEntry(4,27,2019, "Today was a very good day. Melody picked me up and we spent the whole day singing along to our favorite music, starting with 'She's Got a Way' on the car radio, and then Dan's old albums on the record player the rest of the day. I don't know what I'd do without her."),
        new DiaryEntry(4,12,2018, "Keeping the girls for Jordan while she’s out of town. Took them shopping first thing for breakfast foods. Lucky Charms and Pop Tarts, of course. No wonder they love coming to Grandma’s house."),
        new DiaryEntry(4,6,2018,"Still so much to pack for the move. I don't know how I'd do it without all of Melody's help."),
        new DiaryEntry(4,14,2018, "All three children plus their families surprised me for my birthday with Italian Cream cake – my favorite."),
        new DiaryEntry(4,18,2018, "Sorting through the last things for the move & trying to decide what to keep. I hate to leave, but the stairs and everything are too much for me now."),
        new DiaryEntry(4,23,2018, "Mostly finished move into apartments. Last set up is tomorrow"),
        new DiaryEntry(4,26,2018, "In hospital. Had fall on Wednesday. Melody brought me my diary. She's coming to get me tomorrow"),
        new DiaryEntry(4,27,2018, "Today was a very good day. Melody picked me up and we spent the whole day singing along to our favorite music, starting with 'She's Got a Way' on the car radio, and then Dan's old albums on the record player the rest of the day. I don't know what I'd do without her."),


    };
    
}

public class DiaryEntry
{
    public string entryText;
    public int month;
    public int day;
    public int year;

    public DiaryEntry(int _month, int _day, int _year, string _entryText){
        month = _month;
        day = _day;
        year = _year;
        entryText = _entryText;
    }
}

