using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameModeCoupe : MonoBehaviour {

    public static float red_scoreNumber;//记录数据
    public static float greed_scoreNumber;//记录数据
    public GameObject corfRope;
    private float offset;
   private  Vector3 initialPos;
    
    void Start ()
    {
        corfRope=GameObject.Find("bahe");
        initialPos = corfRope.transform.position;
        Init(); 
    }

    public virtual void Init()
    {

    }
   
    void Update ()
    {
        offset = red_scoreNumber - greed_scoreNumber;
        bahe(); 
        //Debug.Log(offset);
        //Debug.Log(initialPos.x);
	}

    void bahe()
    {
        corfRope.transform.DOMoveX(351 - offset *20, 1f);
    }
}
