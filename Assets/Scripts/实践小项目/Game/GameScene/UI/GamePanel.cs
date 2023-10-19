using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //获取控件 关联场景 控件对象 
    //分数
    public CustomGUILabel labScore;
    //时间
    public CustomGUILabel labTime;
    //退出按钮
    public CustomGUIButton btnQuit;
    //设置按钮
    public CustomGUIButton btnSetting;
    //血量图
    public CustomGUITexture texHP;
    //血条控件的宽
    public float hpwW=350;
    //用于记录玩家得分
    [HideInInspector]
    public int nowScore=0;
    [HideInInspector]
    public float nowTime = 0;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        //监听界面上操作控件
        btnSetting.clickEvent += () =>
        {
            //打开设置面板
            SettingPanel.Instance.ShowMe();
            //改变时间 缩放值 为0 时间停止
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () =>
        {
            //返回游戏开始界面
            //弹出一个确认按钮
            QuitPanel.Instance.ShowMe();
            //改变时间 缩放值 为0 时间停止
            Time.timeScale = 0;
        };


    }

    // Update is called once per frame
    void Update()
    {
        //通过帧间隔时间 累加 会比较准确
        nowTime += Time.deltaTime;
        //时间 时间的存储单位是秒
         time = (int)nowTime;
        labTime.content.text = "";
        //得到几小时
        if (time / 3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";
    }
    /// <summary>
    /// 给外部提供加分的方法
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        nowScore += score;
        //用于界面更新
        labScore.content.text = nowScore.ToString();
    }
    /// <summary>
    /// 更新血条的方法
    /// </summary>
    /// <param name="maxHP"></param>
    /// <param name="HP"></param>
    public void UpdateHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpwW;
    }
}
