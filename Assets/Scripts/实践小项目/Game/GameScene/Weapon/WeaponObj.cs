using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //ʵ�����ӵ�����
    public GameObject bullet;
    //�ⲿ���������м�������λ��
    public Transform[] ShootPos;
    //����ӵ����
    public TankBaseObj fatherObj;
    //����ӵ����
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }

    public void Fire()
    {
        //����λ�� ������Ӧ���ӵ�����
        for(int i = 0; i < ShootPos.Length; i++)
        {
            //�����ӵ�Ԥ����
            GameObject obj = Instantiate(bullet, ShootPos[i].position, ShootPos[i].rotation);
            //�����ӵ���ʲô
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherObj);
        }
    }
}
