using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //����Ԥ���� ����
    public GameObject[] rewardObjects;
    //������ЧԤ�������
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //1.���ú��ϰ����ǩ cube�ӵ����Զ��Ƴ�
        //2.���Լ���������������߼�
        //���һ����������ȡ����
        int rangeInt = Random.Range(0, 100);
        //50%�ĸ��� ����һ������
        if (rangeInt < 50)
        {
            //�������һ�� ����Ԥ���� �ڵ�ǰλ��
            rangeInt = Random.Range(0, rewardObjects.Length);
            //�ŵ���ǰ��������λ�ü���
            Instantiate(rewardObjects[rangeInt], this.transform.position, this.transform.rotation);
        }
        //������ЧԤ����
        GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
        //������Ч
        AudioSource audioS = effObj.GetComponent<AudioSource>();
        audioS.volume = GameDataMgr.Instance.musicData.soundValue;
        audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
