using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    //�����ؼ�
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () => {
            //�ص�������
            SceneManager.LoadScene("BeginScene");
        };
        //������Ϸ �ر����
        btnGoOn.clickEvent += () =>
        {
            HideMe();
        };
        //������ �ر����
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
