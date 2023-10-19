using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关联控件
    public CustomGUIButton btnClose;
    //控件过多 拖动工作量过大 代码查找

    private List<CustomGUILabel> labName = new List<CustomGUILabel>();
    private List<CustomGUILabel> labScore = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTime = new List<CustomGUILabel>();
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            //找子对象的子对象 用斜杠来区分父子关系

            labName.Add(this.transform.Find("Name/labName" + i).GetComponent<CustomGUILabel>());
            labScore.Add(this.transform.Find("Score/labScore" + i).GetComponent<CustomGUILabel>());
            labTime.Add(this.transform.Find("Time/labTime" + i).GetComponent<CustomGUILabel>());
        }
        //处理事件监听逻辑
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        //测试增加数据
        //GameDataMgr.Instance.AddRankInfo("ss", 100, 8432);
        HideMe();
        
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    public void UpdatePanelInfo()
    {
        //处理根据排行榜数据 更新面板
        //获取GameData中的排行列表 用于在这里更新
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        //根据列表更新面板数据
        for(int i = 0; i < list.Count; i++)
        {
            //名字
            labName[i].content.text = list[i].name;
            //分数
            labScore[i].content.text = list[i].score.ToString();
            //时间 时间的存储单位是秒
            int time = (int)list[i].time;
            labTime[i].content.text = "";
            //得到几小时
            if (time / 3600 > 0)
            {
                labTime[i].content.text += time / 3600 + "时";
            }
            if (time % 3600 / 60 > 0 || labTime[i].content.text != "")
            {
                labTime[i].content.text += time % 3600 / 60 + "分";
            }
            labTime[i].content.text += time % 60 + "秒";
        }

    }
}
