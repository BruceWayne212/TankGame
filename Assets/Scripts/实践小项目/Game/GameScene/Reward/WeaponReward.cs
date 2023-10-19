using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //�ж��������������� Ԥ����
    public GameObject[] WeaponObj;
    //��ȡ��Ч
    public GameObject getEff;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //������л�����
            int index = Random.Range(0, WeaponObj.Length);
            //�õ�ײ��������Ϲ��صĽű� ������������
            PlayerObj playerObj = other.GetComponent<PlayerObj>();
            playerObj.ChangeWeapon(WeaponObj[index]);
            //����һ��������Ч
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //���ƻ�ȡ��Ч
            AudioSource audioS = eff.GetComponent<AudioSource>();
            //��С�Ϳ���״̬
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            //��ȡ���Լ����Ƴ��Լ�
            Destroy(this.gameObject);
        }
    }

}
