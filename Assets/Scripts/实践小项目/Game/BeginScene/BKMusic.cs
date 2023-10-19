using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;

    public static BKMusic Instance => instance;
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //得到自己依附游戏对象上 挂载的 音频脚本
        audioSource = this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
    }
    //改变背景音乐大小
    public void ChangeValue(float value)
    {
        
        audioSource.volume = value;
    }
    //开关背景音乐
    public void ChangeOpen(bool isOpen)
    {
        //如果开启 就算不静音
        //如果没开启 就是静音
        audioSource.mute = !isOpen;
    }
}
