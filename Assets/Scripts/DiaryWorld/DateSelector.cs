using UnityEngine;

public class DateSelector : MonoBehaviour
{
    public int day;
    public int month;
    public int year;

    public DiaryScript diary;

    public void SetDay(int _day){
        day = _day;
        DateUpdated();
    }

    public void SetMonth(int _month){
        month = _month;
        DateUpdated();
    }

    public void SetYear(int _year){
        year = _year;
        DateUpdated();
    }

    
    void DateUpdated(){
        diary.TurnToDiaryPage(month, day, year);
    }
}
