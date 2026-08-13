using UnityEngine;
using TMPro;

public class NumberSelector : MonoBehaviour
{
    public int maxValue = 31;
    public int minValue = 1;

    public int startValue;
    public int currentValue;

    public TextMeshProUGUI numberText;

    public bool isDayCounter = false;
    public bool isMonthCounter = false;
    public bool isYearCounter = false;

    private bool worldLoadedFirstTime = false;

    public DateSelector dateSelector;

    void Start(){
        WorldLoaded();
    }

    public void UpArrowClicked(){

        if(currentValue + 1 <= maxValue){
            currentValue++;
            UpdateDateValue();
            //numberText.text = "" + currentValue;
        } else {
            currentValue = minValue;
            UpdateDateValue();
            //numberText.text = "" + currentValue;
        }

    }

    public void DownArrowClicked(){

        if(currentValue - 1 >= minValue){
            currentValue--;
            UpdateDateValue();
            //numberText.text = "" + currentValue;
        } else {
            currentValue = maxValue;
            UpdateDateValue();
            //numberText.text = "" + currentValue;
        }

    }

    public void WorldLoaded(){
        if(worldLoadedFirstTime) return;


        currentValue = startValue;
        UpdateDateValue();
        worldLoadedFirstTime = true;
    }

    void UpdateDateValue(){
        

        if(isDayCounter){
            numberText.text = "" + $"{currentValue:D2}";
            dateSelector.SetDay(currentValue);
        } else if(isMonthCounter){
            numberText.text = "" + $"{currentValue:D2}";
            dateSelector.SetMonth(currentValue);
        } else if(isYearCounter) {
            numberText.text = "" + $"{currentValue:D4}";
            dateSelector.SetYear(currentValue);
        }


    }
}
