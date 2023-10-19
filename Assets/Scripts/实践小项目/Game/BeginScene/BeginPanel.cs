using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //申明公共成员变量 来关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    public CustomGUIButton btnTip;

    // Start is called before the first frame update
    void Start()
    {
        //方便坦克头部旋转  锁定鼠标在窗口内
        Cursor.lockState = CursorLockMode.Confined;
        //监听一次按钮点击过后做什么
        btnBegin.clickEvent += ()=>{
            //切换场景
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () => {
            //设置面板
            SettingPanel.Instance.ShowMe();
            //隐藏自己避免穿透
            HideMe();
        };
        btnQuit.clickEvent += () => {
            //退出游戏
            Application.Quit();
        };
        btnRank.clickEvent += () => {
            //打开排行版
            RankPanel.Instance.ShowMe();
            //隐藏自己
            HideMe();
        };
        btnTip.clickEvent += () => {
            //设置面板
            TipPanel.Instance.ShowMe();
            //隐藏自己避免穿透
            HideMe();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
