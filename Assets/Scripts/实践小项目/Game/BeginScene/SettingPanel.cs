using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //������Ա���� �����ؼ�
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        //������Ӧ���¼� �����߼�
        //�������ֵı仯
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);
        //������Ч�ı仯
        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);
        //�������ֵĿ���
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        //������Ч�Ŀ���
        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        btnClose.clickEvent += () =>
        {
            //�����Լ�
            HideMe();
            //�жϵ�ǰ���ڳ���
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                //�ÿ�ʼ���������ʾ
                BeginPanel.Instance.ShowMe();
            }

        };
        HideMe();

    }

    //�������� �����������
    public void UpdatePanelInfo()
    {
        //������Ч���ݸ��� �����Ϣ
        MusicData musicData = GameDataMgr.Instance.musicData;
        //�����������
        sliderMusic.nowValue = musicData.bkValue;
        sliderSound.nowValue = musicData.soundValue;
        togMusic.isSel = musicData.isOpenBK;
        togSound.isSel = musicData.isOpenSound;

    }
    public override void ShowMe()
    {
        base.ShowMe();
        //ÿ����ʾ���ʱ ��������ϵ�����
        UpdatePanelInfo();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
