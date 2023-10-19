using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //要让坦克 在两个点之间 来回移动
    //当前的目标点
    private Transform targetPos;
    //随机用的点 外面去关联
    public Transform[] randomPos;
    //坦克要一直盯着自己的目标
    public Transform lookTarget;
    //当到达一定范围过后 间隔一段时间 攻击一下目标
    public float fireDis = 5;
    //为了避免 过难 增加 攻击时间间隔
    public float fireOffsetTime = 1;
    private float nowTime = 0;

    //开火点 
    public Transform[] shootPos;
    //子弹预设体
    public GameObject bulletObj;

    //两张血条图 外面关联
    public Texture maxHpBK;
    public Texture hpBK;

    //显示血条计时用的时间
    private float showTime;
    //结构体不用new 直接赋值
    private Rect maxHpRect;
    private Rect hpRect;


    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 多个点之间的随机移动
        //看向自己的目标点
        this.transform.LookAt(targetPos);
        //不停地向自己的面朝向移动
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //当距离过小时，认为到达目的地 重新随机找一个点
        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region 看向自己的目标
        if (lookTarget != null)
        {
            tankHead.LookAt(lookTarget);
            //当自己和目标距离 小于等于 配置的开火距离时
            if (Vector3.Distance(this.transform.position, lookTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;

                }
            }
        }
        #endregion


    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
            return;
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Fire()
    {
       for(int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //设置子弹的拥有者用于之后的伤害计算
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }
    public override void Dead()
    {
        base.Dead();
        //移动怪物死亡时 需要加分
        GamePanel.Instance.AddScore(10);
    }
    //在这里进行血条UI的绘制
    private void OnGUI()
    {
        if (showTime > 0)
        {
            //不停计时
            showTime -= Time.deltaTime;

            //绘制血条
            //1.把怪物当前位置 转换成 屏幕位置
            //摄像机里面提供了api 将世界坐标转换成屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //2屏幕位置 转换成GUI 位置
            //得到当前屏幕分辨率的高
            screenPos.y = Screen.height - screenPos.y;

            //进行绘制 GUI的图片绘制
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            //画底图
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHp * 100f;
            hpRect.height = 15;
            //画血条
            GUI.DrawTexture(hpRect, hpBK);
        }


    }
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //设置血条显示的时间
        showTime = 3;
    }
}
