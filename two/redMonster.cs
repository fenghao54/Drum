using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redMonster : GameModeCoupe
{

    public Button player_onclick;
    public Image musicNote;
    public GameObject targetNote;
    public Text score;


    public override void Init()
    {
        musicNote  = GetComponent<Image>();//音乐节节点
        player_onclick = GameObject.Find("Btn_redMonster").GetComponent<Button>();
        player_onclick.onClick.AddListener(CheckRay);//点击监听
        targetNote = GameObject.Find("target_redMonster");
        score = GameObject.Find("red_score").GetComponent<Text>();
       
    }
	
    void CheckRay()
    {
        RaycastHit hit;
        Debug.DrawRay(musicNote .transform.position, new Vector3(0, 0, 10), Color.blue, 5);
        if (Physics.Raycast(musicNote.transform.position, new Vector3(0, 0, 1), out hit, 200))
        {
            if (hit.collider.gameObject == targetNote)
            {
               
                Destroy(musicNote.gameObject);
                red_scoreNumber++;
                score.text = "Score:" + red_scoreNumber.ToString();
            }
        }
    }
}
