using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    //关联控件 
    public CustomGUIInput inputInfo;
    public CustomGUIButton btnSure;

    // Start is called before the first frame update
    void Start()
    {
        btnSure.clickEvent += () =>
        {
            //取消游戏暂停
            Time.timeScale = 1;
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore,
                GamePanel.Instance.nowTime);
            //返回开始界面
            SceneManager.LoadScene("BeginScene");
        };
        HideMe();
    }


}
