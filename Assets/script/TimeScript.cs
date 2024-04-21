using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public static TimeScript instance { get; private set; }    
    [SerializeField]public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerText;
    [SerializeField] Image image;
    [SerializeField]Sprite spriteHouse1;
    [SerializeField]Sprite spriteHouse2;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        TimerOn=true;
        animator.SetBool("isMove", false);
        
 
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(TimerOn){
            if(TimeLeft>0){
                TimeLeft-=Time.deltaTime;
                updateTimer(TimeLeft);
                
            }
            else{
                Debug.Log("Death and agony!");
                TimeLeft=0;
                TimerOn=false;
            }
        }



        if (TimeLeft <= 0) { 
        
        StartCoroutine(Visuals(spriteHouse1, spriteHouse2));

        }
    }
    void updateTimer(float currentTime){
        currentTime +=1;
        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);   
        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }





    //IEnumerator Visuals(Sprite sprite1, Sprite sprite2)
    //{
    //    Instantiate(sprite1);
    //    image.sprite = sprite1;
    //    yield return new WaitForSeconds(5f);
    //    Instantiate(sprite2);
    //    image.sprite = sprite2;
    //    yield return new WaitForSeconds(5f);
    //    SceneManager.LoadScene("END");
    //    animator.SetBool("isMove", true);
    //}
    IEnumerator Visuals(Sprite sprite1, Sprite sprite2)
    {
        image.sprite = sprite1;
        yield return new WaitForSeconds(3f);
        image.sprite = sprite2;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("END");
        animator.SetBool("isMove", true);
    }




}
