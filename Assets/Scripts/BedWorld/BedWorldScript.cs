using UnityEngine;

public class BedWorldScript : WorldScript
{
    public GameObject electricityOne;
    public GameObject electricityTwo;
    public GameObject electricityThree;

    public override void ThisWorldJustActivated(){
        electricityOne.SetActive(false);
        electricityTwo.SetActive(false);
        electricityThree.SetActive(false);
    }

}
