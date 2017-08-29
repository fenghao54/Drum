using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MusicNoteCoupe1 : GameMode
{
    public GameObject musicNote;//实例化的音符
    
    private Image target;//目标位置
    public Image start;//开始位置
    public  Transform parent;//设置父级
    private float timeSpace;//控制生成的时间间隔
   
  
    void Start ()
	{
	    musicNote =  Resources.Load("UI/Coupe/greedMonster") as GameObject;//获取音符
        target = gameObject.transform.Find("end_greedMonster").GetComponent<Image>();
        start = gameObject.transform.Find("start_greedMonster").GetComponent<Image>();
	    parent = GetComponent<Transform>();

	}

    void Update()
    {
        TimeSpace();  
    }

    void Move(GameObject  musicNote_new)//移动音符
    {
        musicNote_new.transform.DOMoveX(target.transform.position.x, 3).SetEase(Ease.Linear);
    }

    void Initial()//实例化音符
    {
        var start_new=Instantiate(musicNote, start.transform.position, Quaternion.identity);
        Move(start_new);
        start_new.transform.SetParent(parent);
        Destroy(start_new,3f);
    }
    

    void TimeSpace()//第一种音符间隔时间
    {
        if (timeSpace > 0)
        {
            timeSpace -= Time.deltaTime;
            if (timeSpace < 0.1f)//当时间小于预订时间，实例一个音符
            {
                Initial();
                timeSpace = 0;
            }
            return;
        }
        timeSpace = Random.Range(2.1f, 3.1f);
    }

   
}
