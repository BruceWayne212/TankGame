using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipPanel : BasePanel<TipPanel>
{
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
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


}
