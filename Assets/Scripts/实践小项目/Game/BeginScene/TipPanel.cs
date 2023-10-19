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


}
