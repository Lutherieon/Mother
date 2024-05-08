using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public static TimeScript instance;
    public  static float TimeLeft = 60f; // Example starting time
    public bool TimerOn = false;
    public Text TimerText;
    [SerializeField] private Image image;
    [SerializeField] private Sprite spriteHouse1;
    [SerializeField] private Sprite spriteHouse2;
    [SerializeField] private DialogueSystem dialogueSystem;
    private Animator animator;
    private bool visualsRunning = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        TimerOn = true;
        animator.SetBool("isMove", false);
    }

    void Update()
    {
        if (TimerOn)
        {
            if (dialogueSystem.GetComponent<DialogueSystem>().isDialogue == false)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    UpdateTimer(TimeLeft);
                }
                else
                {
                    Debug.Log("Death and agony!");
                    TimeLeft = 0;
                    TimerOn = false;
                    if (!visualsRunning && spriteHouse1 != null && spriteHouse2 != null)
                    {
                        StartCoroutine(Visuals(spriteHouse1, spriteHouse2));
                    }
                }
            }
            else
            {
                return;
            }
            
        }
    }

    void UpdateTimer(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator Visuals(Sprite sprite1, Sprite sprite2)
    {
        visualsRunning = true;
        image.sprite = sprite1;
        yield return new WaitForSeconds(3f);
        image.sprite = sprite2;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("END");
        animator.SetBool("isMove", true);
        visualsRunning = false;
    }




    //    public static TimeScript instance { get; private set; }    
    //    [SerializeField]public static float TimeLeft;
    //    public bool TimerOn = false;
    //    public Text TimerText;
    //    [SerializeField] Image image;
    //    [SerializeField]Sprite spriteHouse1;
    //    [SerializeField]Sprite spriteHouse2;
    //    Animator animator;

    //    void Start()
    //    {
    //        animator = GetComponent<Animator>();
    //        TimerOn=true;
    //        animator.SetBool("isMove", false);


    //    }

    //    private void Awake()
    //    {
    //        if(instance != null && instance != this)
    //        {
    //            Destroy(gameObject);
    //            return;
    //        }

    //        instance = this;

    //        DontDestroyOnLoad(gameObject);
    //    }
    //    void Update()
    //    {
    //        if(TimerOn){
    //            if(TimeLeft>0){
    //                TimeLeft-=Time.deltaTime;
    //                updateTimer(TimeLeft);

    //            }
    //            else{
    //                Debug.Log("Death and agony!");
    //                TimeLeft=0;
    //                TimerOn=false;
    //            }
    //        }



    //        if (TimeLeft <= 0 && spriteHouse1 !=null || spriteHouse2 !=null) { 

    //        StartCoroutine(Visuals(spriteHouse1, spriteHouse2));

    //        }
    //    }
    //    void updateTimer(float currentTime){
    //        currentTime +=1;
    //        float minutes = Mathf.FloorToInt(currentTime/60);
    //        float seconds = Mathf.FloorToInt(currentTime%60);   
    //        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    //    }





    //    //IEnumerator Visuals(Sprite sprite1, Sprite sprite2)
    //    //{
    //    //    Instantiate(sprite1);
    //    //    image.sprite = sprite1;
    //    //    yield return new WaitForSeconds(5f);
    //    //    Instantiate(sprite2);
    //    //    image.sprite = sprite2;
    //    //    yield return new WaitForSeconds(5f);
    //    //    SceneManager.LoadScene("END");
    //    //    animator.SetBool("isMove", true);
    //    //}
    //    IEnumerator Visuals(Sprite sprite1, Sprite sprite2)
    //    {
    //        image.sprite = sprite1;
    //        yield return new WaitForSeconds(3f);
    //        image.sprite = sprite2;
    //        yield return new WaitForSeconds(3f);
    //        SceneManager.LoadScene("END");
    //        animator.SetBool("isMove", true);
    //    }




}




