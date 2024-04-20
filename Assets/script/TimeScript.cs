using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField]public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerText;
    void Start()
    {
        TimerOn=true;
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
    }
    void updateTimer(float currentTime){
        currentTime +=1;
        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);   
        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
