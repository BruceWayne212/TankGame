using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //相关属性 攻击力 防御力 最大血量 当前血量
    public int atk;
    public int def;
    public int maxHp;
    public int hp;

    //所有坦克都有炮台
    public Transform tankHead;

    //移动速度 旋转速度 炮管旋转速度
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //死亡特效 关联预设体 动态创建后设置位置
    public GameObject deadEff;


    /// <summary>
    /// 开火抽象方法 子类重写开火行为即可
    /// </summary>
    public abstract void Fire();

    /// <summary>
    /// 我被攻击了 血量减少
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(TankBaseObj other)
    {
        // 伤害技术 别人的攻击力减去自己防御力
        int dmg = other.atk - this.def;
        //伤害判断 伤害大于0才减血
        if (dmg <= 0)
            return;
        this.hp -= dmg;
        //判断当前血量 <=0 就应死亡
        if (this.hp <= 0)
        {
            //避免负数时 影响血条
            this.hp = 0;
            this.Dead();
        }
    }
    /// <summary>
    /// 死亡行为（血量小于等于0）
    /// </summary>
    public virtual void Dead()
    {
        //对象死亡 移除场景上的该对象
        Destroy(this.gameObject);
        //当坦克死亡的时候播放 死亡特性
        if (deadEff != null)
        {
            //实例化对象时 设置位置 旋转角度
            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            //由于预设体 对象上关联了音效 所以可以在这里直接设置
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            //根据音乐数据是否播放音效大小
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            //音效开关 设置成静音
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            audioSource.Play();
        }

    }
}
