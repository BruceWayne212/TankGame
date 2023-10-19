using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{

    //当前装备的武器
    public WeaponObj nowWeapon;

    //武器父对象位置
    public Transform weaponPos;


    // Update is called once per frame
    void Update()
    {
        //ws键控制前进后退
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        //ad键控制旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //鼠标左右移动控制 炮台旋转
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headRoundSpeed * Time.deltaTime);
        //开火
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
        //防止移除摄像机
        //base.Dead();
        //处理失败逻辑 显示失败面板
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板 血条
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        //滞空当前武器
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //切换武器
        //创建出武器并设置它的父对象 并保证缩放没什么问题
        GameObject weaponObj = Instantiate(weapon,weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
