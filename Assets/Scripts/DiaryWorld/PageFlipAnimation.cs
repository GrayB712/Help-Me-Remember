using UnityEngine;

public class PageFlipAnimation : MonoBehaviour
{
    public DiaryScript diary;

    public SpriteRenderer maskRenderer;
    public Sprite[] spriteMaskImages;
    public float timeBetweenSpriteSwaps = 0.067f;
    private int currentSprite = 0;
    private float timer = 0f;
    public bool isAnimating {get; set;} = true;
    bool inReverse = false;

    public GameObject spriteObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maskRenderer = spriteObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimating){
            timer += Time.deltaTime;
            if(timer > timeBetweenSpriteSwaps){
                timer = 0f;

                if(!inReverse){
                    currentSprite++;
                    if(currentSprite >= spriteMaskImages.Length){
                        isAnimating = false;
                        spriteObject.SetActive(false);
                        diary.FinishedAnimation();
                    }
                } else{

                    currentSprite--;
                    if(currentSprite < 0){
                        isAnimating = false;
                        spriteObject.SetActive(false);
                        diary.FinishedAnimation();
                    }
                }

                if(currentSprite >= 0 && currentSprite < spriteMaskImages.Length){
                    maskRenderer.sprite = spriteMaskImages[currentSprite];
                }                
                

                
            }
        }
    }

    public void RunAnimation(bool _inReverse){
        inReverse = _inReverse;
        isAnimating = true;

        if(!inReverse){
            currentSprite = 0;
        } else{
            currentSprite = spriteMaskImages.Length - 1;
        }
        
        spriteObject.SetActive(true);
        maskRenderer.sprite = spriteMaskImages[currentSprite];
    }
}
