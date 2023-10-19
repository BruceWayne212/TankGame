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
        //�õ��Լ�������Ϸ������ ���ص� ��Ƶ�ű�
        audioSource = this.GetComponent<AudioSource>();
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);
    }
    //�ı䱳�����ִ�С
    public void ChangeValue(float value)
    {
        
        audioSource.volume = value;
    }
    //���ر�������
    public void ChangeOpen(bool isOpen)
    {
        //������� ���㲻����
        //���û���� ���Ǿ���
        audioSource.mute = !isOpen;
    }
}
