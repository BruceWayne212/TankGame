using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{

    //��ǰװ��������
    public WeaponObj nowWeapon;

    //����������λ��
    public Transform weaponPos;


    // Update is called once per frame
    void Update()
    {
        //ws������ǰ������
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        //ad��������ת
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //��������ƶ����� ��̨��ת
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);
        //����
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null)
            nowWeapon.Fire();
    }
    public override void Dead()
    {
        //��ֹ�Ƴ������
        //base.Dead();
        //����ʧ���߼� ��ʾʧ�����
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //��������� Ѫ��
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }
    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        //�Ϳյ�ǰ����
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //�л�����
        //�������������������ĸ����� ����֤����ûʲô����
        GameObject weaponObj = Instantiate(weapon,weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
