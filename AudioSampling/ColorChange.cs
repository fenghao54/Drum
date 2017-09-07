using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{

    public Image smallBlock;
    public List<Image> smallBlocks=new List<Image>();
    public int[] smallslipNum=new int[28];
    public Transform smallBlockparent;
    void Start ()
    {
        smallBlock = Resources.Load<Image>("smallBlock");
    }
	
	
	void Update () {
        SmallBlockNum();
		
	}

    void SmallBlockNum()//用来计算每一条小方格的数量
    {
        for (int i = 0; i < smallslipNum.Length; i++)
        {
            smallslipNum[i]=Mathf.CeilToInt(AudioSampling.Instance.musicData[i] * 70);

        } 
        IntialSmallBlock();
    }

    void IntialSmallBlock()
    {
        for (int i = 0; i < 27; i++)//一种有多少条
        {
            for (int n = 0; n < smallslipNum[i]; n++)//每一条是多少个方格
            {
                
                var x = i*40;
                var y = n*30;
                var a = Instantiate(smallBlock, transform.position, Quaternion.identity);
                a.transform.SetParent(smallBlockparent);
                a.transform.localPosition=new Vector3(x,y,0);
                Destroy(a.gameObject,0.1f);
            }
        }
    }
}
