using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class instanceSqeue : MonoBehaviour
{
    

   
    private Vector3 center;
    private float radius=25;
    private float angle;
    public Transform parent;
    private Image yuan;
    private Image fang;
    List<Vector3> initalPos=new List<Vector3>(); 
    private List<Image> smallCircle=new List<Image>();
    //List<ImagePosition> smallCriclePos=new List<ImagePosition>();
    private LineRenderer line;
    public GameObject line1;
    


    void Start()
    {
        //center = gameObject.transform.position;
        yuan = Resources.Load<Image>("xiaoyuan");
        fang = Resources.Load<Image>("fang");
     
        //InitalCricle();
        InitalCube();
    }


    void Update ()
    {
        //MoveCircle();
        Movecube();
    }

    void InitalCricle()
    {
 
        //20度生成一个圆  
        for (angle = 0; angle < 360; angle += 6)
        {
            
            // x = 原点x + 半径 * 邻边除以斜边的比例,   邻边除以斜边的比例 = cos(弧度) , 弧度 = 角度 *3.14f / 180f;     
            float x =  radius * Mathf.Cos(angle * 3.14f / 180f);
            float y =  radius * Mathf.Sin(angle * 3.14f / 180f);
            // 生成一个圆  
            var obj1 = Instantiate(yuan);
            //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数    
            obj1.transform.SetParent(parent);
            obj1.transform.localScale = Vector3.one;
            obj1.transform.localPosition = new Vector3(x, y, 0);
            obj1.transform.rotation = Quaternion.Euler(0, 0, angle);
            initalPos.Add(obj1.transform.localPosition);
            smallCircle.Add(obj1);
        }


        line1 = Resources.Load<GameObject>("line");
        var a = Instantiate(line1, transform.position, Quaternion.identity);
        a.transform.SetParent(parent);
        a.transform.localScale = Vector3.one;
        line = a.GetComponent<LineRenderer>();

        line.positionCount = smallCircle.Count;
    }

    void InitalCube()
    {

        //20度生成一个圆  
        for (angle = 0; angle < 360; angle += 6)
        {

            // x = 原点x + 半径 * 邻边除以斜边的比例,   邻边除以斜边的比例 = cos(弧度) , 弧度 = 角度 *3.14f / 180f;     
            float x = radius * Mathf.Cos(angle * 3.14f / 180f);
            float y = radius * Mathf.Sin(angle * 3.14f / 180f);
            // 生成一个圆  
            var obj1 = Instantiate(fang);
            //设置物体的位置Vector3三个参数分别代表x,y,z的坐标数    
            obj1.transform.SetParent(parent);
            obj1.transform.localScale = Vector3.one;
            obj1.transform.localPosition = new Vector3(x, y, 0);
            obj1.transform.rotation = Quaternion.Euler(0, 0, angle);
            initalPos.Add(obj1.transform.localPosition);
            smallCircle.Add(obj1);
        }


    }

    void MoveCircle()
    {

        for (int i = 0; i < smallCircle.Count; i++)
        {
            var targetPos = initalPos[i] +
                            smallCircle[i].transform.right * (1 + AudioSampling.Instance.musicData[i + 10] * 1000);

            targetPos.z = 0;
            smallCircle[i].transform.localPosition = Vector3.Lerp(initalPos[i],targetPos,1f);
            line.SetPosition(i, smallCircle[i].transform.position);
            line.startWidth = 0.3f;
            line.endWidth = 0.3f;
        }
 
    }

    void Movecube()
    {
        for (int i = 0; i < smallCircle.Count; i++)
        {
            //smallCircle[i].transform.DOScaleY(AudioSampling.Instance.musicData[i + 10] * 50, 0.1f);
            Debug.Log(AudioSampling.Instance.musicData[i] * 50);
            var a = AudioSampling.Instance.musicData[i+3] * 50;
            if ( a> 12)
            {
                a -= 6;
            }
            if (a > 15)
            {
                a -= 10;
            }
            smallCircle[i].transform.DOScaleX(a, 0.15f);
        }
    }



}
