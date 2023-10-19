using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    //关联控件
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () => {
            //回到主界面
            SceneManager.LoadScene("BeginScene");
        };
        //继续游戏 关闭面板
        btnGoOn.clickEvent += () =>
        {
            HideMe();
        };
        //叉掉面板 关闭面板
        btnClose.clickEvent += () =>
        {
            HideMe();
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
