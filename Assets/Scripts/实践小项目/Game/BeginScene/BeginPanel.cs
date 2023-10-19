using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //����������Ա���� �����������ؼ�
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    public CustomGUIButton btnTip;

    // Start is called before the first frame update
    void Start()
    {
        //����̹��ͷ����ת  ��������ڴ�����
        Cursor.lockState = CursorLockMode.Confined;
        //����һ�ΰ�ť���������ʲô
        btnBegin.clickEvent += ()=>{
            //�л�����
            SceneManager.LoadScene("GameScene");
        };
        btnSetting.clickEvent += () => {
            //�������
            SettingPanel.Instance.ShowMe();
            //�����Լ����⴩͸
            HideMe();
        };
        btnQuit.clickEvent += () => {
            //�˳���Ϸ
            Application.Quit();
        };
        btnRank.clickEvent += () => {
            //�����а�
            RankPanel.Instance.ShowMe();
            //�����Լ�
            HideMe();
        };
        btnTip.clickEvent += () => {
            //�������
            TipPanel.Instance.ShowMe();
            //�����Լ����⴩͸
            HideMe();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
