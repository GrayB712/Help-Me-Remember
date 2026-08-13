using UnityEngine;
using TMPro;

public class DiaryScript : MonoBehaviour
{
    public DiaryEntries diaryEntries;
    public int month;
    public int day;
    public int year;

    private string currentDiaryEntry = "";

    public TextMeshProUGUI diaryDateText;
    public TextMeshProUGUI diaryEntryText;
    //public GameObject dateTextObject;

    public PageFlipAnimation animator;


    public void TurnToDiaryPage(int _month, int _day, int _year){

        FinishedAnimation();

        bool turnedForwards;

        if(_year < year){
            turnedForwards = false;
        } else if(_year > year){
            turnedForwards = true;
        } else if(_month < month){
            turnedForwards = false;
        } else if (_month > month){
            turnedForwards = true;
        } else if(_day < day){
            turnedForwards = false;
        } else{
            turnedForwards = true;
        }

        month = _month;
        day = _day;
        year = _year;
        
        animator.RunAnimation(!turnedForwards);
        
        

        string newDiaryEntry = CheckForDiaryEntry(month, day, year);
        currentDiaryEntry = newDiaryEntry;

        if(turnedForwards){
            diaryDateText.text = $"{month:D2}" + "/" + $"{day:D2}" + "/" + $"{year:D4}";
            diaryEntryText.text = newDiaryEntry;
        }

        GameEventManager.current.GetEvent(GameEventManager.GameEvent.BeginDiaryPageTurn).Invoke();
        

    }

    public void FinishedAnimation(){
        diaryDateText.text = $"{month:D2}" + "/" + $"{day:D2}" + "/" + $"{year:D4}";
        diaryEntryText.text = currentDiaryEntry;
    }

    private string CheckForDiaryEntry(int newMonth, int newDay, int newYear){
        string matchingEntry = "";
        foreach(DiaryEntry entry in diaryEntries.allEntries){
            if(entry.day == newDay && entry.month == newMonth && entry.year == newYear){
                matchingEntry = entry.entryText;
            }
        }
        return matchingEntry;
    }



}
