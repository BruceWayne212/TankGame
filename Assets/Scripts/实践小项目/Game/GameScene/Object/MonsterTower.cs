using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //间隔开火 设置间隔开火时间
    public float fireOffsetTime = 1;
    //累加时间 用于开火判断
    private float nowTime = 0;
    //发射位置
    public Transform[] shootPos;
    //子弹 预设体关联
    public GameObject bulletObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //不停的累加时间 并记录下来
        nowTime += Time.deltaTime;
        //当时间超过间隔时间 就开火
        if (nowTime > fireOffsetTime)
        {
            Fire();
            nowTime = 0;
        }
    }
    public override void Fire()
    {
        for(int i = 0; i < shootPos.Length; i++)
        {
            //几个发射点 就实例化几个子弹 
            GameObject obj = Instantiate(bulletObj, shootPos[i].position,shootPos[i].rotation);
            //这里是设置子弹的拥有者 方便之后的 属性计算
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Wound(TankBaseObj other)
    {
        //什么都不写
        //固定不动的坦克 它可以不被伤害 永远不会死亡

    }
}
