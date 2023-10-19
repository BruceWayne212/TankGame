using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:class
{
    //有两个关键的静态成员
    //私有的静态成员变量（申明）
    private static T instance;
    //公共的静态成员属性或方法(获取)
    public static T Instance => instance;

    private void Awake()
    {
        //在Awake初始化的原因是 我们面板脚本在场景上只会挂载一次
        //那么我们可以在这个生命周期函数Awake中 直接记录场景 唯一的脚本
        instance = this as T;
    }

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }
}
