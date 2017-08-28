using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MusicNote : MonoBehaviour
{
    public GameObject musicNote;//实例化的音符
    public GameObject musicNote1;//实例化的音符
    private Image target;//目标位置
    public Image start;//开始位置
    public  Transform parent;//设置父级
    private float timeSpace;//控制生成的时间间隔
    private float timeSpace2;//控制生成的时间间隔
    public int scoreNumber;//记录数据
    public int missNumber;


    void Start ()
	{
	    musicNote =  Resources.Load("UI/Img_musicNote")as GameObject;
        musicNote1 = Resources.Load("UI/Img_musicNote 1") as GameObject;
        target = gameObject.transform.Find("Img_target").GetComponent<Image>();
        start = gameObject.transform.Find("Img_start").GetComponent<Image>();
	    parent = GetComponent<Transform>();

	}

    void Update()
    {
        TimeSpace();
        TimeSpace2();
    }

    void Move(GameObject  musicNote_new)//移动音符
    {
        musicNote_new.transform.DOMoveX(target.transform.position.x-200, 2).SetEase(Ease.Linear);
    }

    void Initial()//实例化音符
    {
        var start_new=Instantiate(musicNote, start.transform.position, Quaternion.identity);
        Move(start_new);
        start_new.transform.SetParent(parent);
        Destroy(start_new,2f);
    }
    void Initial2()//实例化音符
    {
        var start_new = Instantiate(musicNote1, start.transform.position, Quaternion.identity);
        Move(start_new);
        start_new.transform.SetParent(parent);
        Destroy(start_new, 2f);
    }

    void TimeSpace()
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
        timeSpace = Random.Range(0.1f, 3.1f);
    }

    void TimeSpace2()
    {
        if (timeSpace2 > 0)
        {
            timeSpace2 -= Time.deltaTime;
            if (timeSpace2 < 0.1f)//当时间小于预订时间，实例一个音符
            {
                Initial2();
                timeSpace2 = 0;
            }
            return;
        }
        timeSpace2 = Random.Range(2.1f, 5.1f);
    }
}
