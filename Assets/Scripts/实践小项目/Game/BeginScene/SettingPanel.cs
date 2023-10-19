using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //申明成员变量 关联控件
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        //监听对应的事件 处理逻辑
        //处理音乐的变化
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);
        //处理音效的变化
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //处理音乐的开关
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //处理音效的开关
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        btnClose.clickEvent += () =>
        {
            //隐藏自己
            HideMe();
            //判断当前所在场景
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                //让开始面板重新显示
                BeginPanel.Instance.ShowMe();
            }

        };
        HideMe();

    }

    //根据数据 更新面板数据
    public void UpdatePanelInfo()
    {
        //根据音效数据更新 面板信息
        MusicData musicData = GameDataMgr.Instance.musicData;
        //设置面板内容
        sliderMusic.nowValue = musicData.bkValue;
        sliderSound.nowValue = musicData.soundValue;
        togMusic.isSel = musicData.isOpenBK;
        togSound.isSel = musicData.isOpenSound;

    }
    public override void ShowMe()
    {
        base.ShowMe();
        //每次显示面板时 更新面板上的数据
        UpdatePanelInfo();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
