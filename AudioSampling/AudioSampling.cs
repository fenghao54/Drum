using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioSampling : MonoBehaviour
{


    public static AudioSampling Instance;

    public AudioSource music;
    public GameObject fangkuai;
    public Transform parent;
    public GameObject sphere;
    public float mathAvg;
   
    public int xPos=0;
    public float time;
    public float[] musicData=new float[512];
    public GameObject[] musicNote=new GameObject[512];
    public List<GameObject > musicSqhere=new List<GameObject>();

    void OnEnable()
    {
        if (!Instance)
        {
            Instance = this;
        }

    }

    void Start ()
	{
	    //fangkuai = Resources.Load<GameObject>("fangkuai");
	    //sphere = Resources.Load<GameObject>("yuan");
	    //instant();
	   
	}
	
	
	void Update ()
    {
        
        music = GetComponent<AudioSource>();
        musicData = music.GetSpectrumData(512, 0, FFTWindow.Triangle);
        //if (time > 5)
        //{
        //    time = 0;
        //    xPos = 0;
        //    musicSqhere.Clear();
        //}
        //time += Time.deltaTime;
        //xPos++;
        //MathAvg();
        //instantSq();
        //changeNote();
    }

    //void MathAvg()//每一帧的平均值
    //{ 
    //    for(int i = 0; i < 10;i++)
    //    {
    //        mathAvg += musicData[i];
    //    }
    //     mathAvg = mathAvg / 10;
    //}

    //void instantSq()//初始化一个球
    //{
    //    GameObject a = Instantiate(sphere, new Vector3(xPos*2, mathAvg*1000, 0), Quaternion.identity);
    //    musicSqhere.Add(a);
        
    //    Destroy(a,5-time);
    //    for (int i = 0; i < musicSqhere.Count - 1; i++)
    //    {
    //        Debug.DrawLine(musicSqhere[i].transform.position,musicSqhere[i+1].transform.position,Color.blue,0.2f);
    //    }
    //}



    //void instant()
    //{
    //    for (int i = 0; i < 512; i++)
    //    {
    //        var a=Instantiate(fangkuai, new Vector3(parent.transform.position.x + i, 0, 0), Quaternion.identity);
    //        musicNote[i] = a;
    //    }
    //}

    //void changeNote()
    //{
    //    for (int i = 0; i <512; i++)
    //    {
    //        musicNote[i].transform.DOScaleY(musicData[i] * 100, 0.1f);

    //    }
    //}
}
