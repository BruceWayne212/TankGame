using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //������� ������ ������ ���Ѫ�� ��ǰѪ��
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    //����̹�˶�����̨
    public Transform tankHead;

    //�ƶ��ٶ� ��ת�ٶ� �ڹ���ת�ٶ�
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //������Ч ����Ԥ���� ��̬����������λ��
    public GameObject deadEff;


    /// <summary>
    /// ������󷽷� ������д������Ϊ����
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// �ұ������� Ѫ������
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        // �˺����� ���˵Ĺ�������ȥ�Լ�������
        int dmg = other.atk - this.def;
        //�˺��ж� �˺�����0�ż�Ѫ
        if (dmg <= 0)
            return;
        this.hp -= dmg;
        //�жϵ�ǰѪ�� <=0 ��Ӧ����
        if (this.hp <= 0)
        {
            //���⸺��ʱ Ӱ��Ѫ��
            this.hp = 0;
            this.Dead();
        }
    }
    /// <summary>
    /// ������Ϊ��Ѫ��С�ڵ���0��
    /// </summary>
    public virtual void Dead()
    {
        //�������� �Ƴ������ϵĸö���
        Destroy(this.gameObject);
        //��̹��������ʱ�򲥷� ��������
        if (deadEff != null)
        {
            //ʵ��������ʱ ����λ�� ��ת�Ƕ�
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            //����Ԥ���� �����Ϲ�������Ч ���Կ���������ֱ������
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            //�������������Ƿ񲥷���Ч��С
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            //��Ч���� ���óɾ���
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }

    }
}
