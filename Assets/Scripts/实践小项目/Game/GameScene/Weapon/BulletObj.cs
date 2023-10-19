using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    //移动速度
    public float moveSpeed = 50;
    //谁发射的我
    public TankBaseObj fatherObj;
    //特效对象
    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    //和别人碰撞触发
    private void OnTriggerEnter(Collider other)
    {
        //子弹射击到立方体会爆炸
        //子弹射击到不同阵营的坦克也应该爆炸
        if (other.CompareTag("Cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster")&& fatherObj.CompareTag("Player"))
        {
            //判断是否受伤
            //得到发射对象上的相关脚本 里氏替换 
            //通过父类获取
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
                obj.Wound(fatherObj);
            //当子弹销毁时 可以创建 一个爆炸特效
            if (effObj != null)
            {
                //创建爆炸特效
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //设置音效大小 开启状态
                AudioSource audioS = eff.GetComponent<AudioSource>();
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;
                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            }
            Destroy(this.gameObject);
        }
        
    }
    //设置拥有者
    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
