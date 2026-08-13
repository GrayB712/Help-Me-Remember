using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject electricOutline;
    public GameObject buttonClicked;

    public void OnPointerClick(PointerEventData eventData){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void OnPointerEnter(PointerEventData eventData){
        if(electricOutline != null){
            electricOutline.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData){
        if(electricOutline != null){
            electricOutline.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        if(buttonClicked != null)
            buttonClicked.SetActive(true);
    }

}
