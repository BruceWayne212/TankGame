using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T:class
{
    //�������ؼ��ľ�̬��Ա
    //˽�еľ�̬��Ա������������
    private static T instance;
    //�����ľ�̬��Ա���Ի򷽷�(��ȡ)
    public static T Instance => instance;

    private void Awake()
    {
        //��Awake��ʼ����ԭ���� �������ű��ڳ�����ֻ�����һ��
        //��ô���ǿ���������������ں���Awake�� ֱ�Ӽ�¼���� Ψһ�Ľű�
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
