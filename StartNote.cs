using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNote : MonoBehaviour
{
    public Button player_onclick;
    public  Image startNote;
    public  GameObject targetNote;
    public GameObject missNote;
    public Text score;
    public Text miss;
    public MusicNote musicNote;
    

    void Start ()
	{
	    musicNote = GameObject.Find("Img_bg").GetComponent<MusicNote>();
	    startNote = GetComponent<Image>();//音乐节节点
	    player_onclick = GameObject.Find("Btn_player").GetComponent<Button>();
        player_onclick.onClick.AddListener(CheckRay);//点击监听
	    targetNote = GameObject.Find("Img_trigger");
        missNote= GameObject.Find("Img_miss");
	    score = GameObject.Find("Txt_score").GetComponent<Text>();
        miss = GameObject.Find("Txt_miss").GetComponent<Text>();
    }
	
	
	void Update ()
	{
	    CheckMiss();
	}

    void CheckRay()
    {
        RaycastHit hit;
        Debug.DrawRay(startNote.transform.position,new Vector3(0,0,10),Color.blue,5);
        if (Physics.Raycast(startNote.transform.position, new Vector3(0, 0, 1), out hit, 200))
        {
            if (hit.collider.gameObject == targetNote)
            {
                Destroy(startNote.gameObject);
                musicNote.scoreNumber++;
                score.text = "Score:" + musicNote.scoreNumber.ToString();
            }
        }
    }

    void CheckMiss()//测量miss的数量
    {
        float offset=(missNote.transform.position - startNote.transform.position).magnitude;
        if (offset<10)
        {
            musicNote.missNumber++;
            miss.text = "Miss:" + musicNote.missNumber.ToString();
            Destroy(startNote.gameObject);
        }
    }


}
