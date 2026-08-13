using UnityEngine;

public class DiaryWorldScript : WorldScript
{

    public NumberSelector day;
    public NumberSelector month;
    public NumberSelector year;

    public override void ThisWorldJustActivated(){
        if(day != null){
            day.WorldLoaded();
        }
        if(month != null){
            month.WorldLoaded();
        }
        if(year != null){
            year.WorldLoaded();
        }
    }


}
