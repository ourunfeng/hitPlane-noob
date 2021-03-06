using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form打飞机
{
    class SingleObject
    {

        #region  单例设计模式
        //1、构造函数私有化
        private SingleObject()
        {

        }
        //2、声明全局唯一的一个变量
        private static SingleObject _single = null;

        //3、提供一个静态函数用于返回一个唯一的对象
        public static SingleObject GetSingle()
        {
            if (_single == null)
            {
                _single = new SingleObject();
            }
            return _single;
        }
        #endregion

        //在单例类中储存背景对象
        public Backround BG { get; set; }
        //在单例类中储存英雄对象
        public HeroPlane Hero { get; set; }
        
        //储存敌人飞机类型的泛型集合
        public List<EnemyPlane> ListEnemyPlane = new List<EnemyPlane>();

        //储存玩家子弹类型的泛型集合
        public List<HeroZidan> ListHeroZidan = new List<HeroZidan>();

        //储存敌人子弹类型的泛型集合
        public List<EnemyZidan> listEnemyZidan = new List<EnemyZidan>();
        int f = 0;
        public int Sore { get; set; }

        /// <summary>
        /// 用于碰撞检测
        /// </summary>
        public void PZJC()
        {
            //检测玩家子弹是否打中敌人的飞机
            for (int i = 0; i < ListHeroZidan.Count; i++)
            {
                //玩家每打出的一发子弹都进入j循环，用于检测是否打中敌人的飞机
                for (int j = 0; j < ListEnemyPlane.Count; j++)
                {
                    if (ListHeroZidan[i].GetRctangle().IntersectsWith(ListEnemyPlane[j].GetRctangle()))
                    {
                        //如果成立则表明击中了敌人，敌人的生命值减少
                        ListEnemyPlane[j].Hp -= ListHeroZidan[i].Power;
                        
                        if (ListEnemyPlane[j].Hp <=0)
                        {
                            SingleObject.GetSingle().ListEnemyPlane[j].IsOver();
                            

                        }
                        ListHeroZidan.Remove(ListHeroZidan[i]);
                        break;

                    }
                    


                }

            }
            this.Sore = Hero.Hp;
            //检测子弹是否打中玩家飞机
            for (int i = 0; i < listEnemyZidan.Count; i++)
            {
                //敌人每打出的一发子弹都进入i循环，用于检测是否打中敌人的飞机

                    if (listEnemyZidan[i].GetRctangle().IntersectsWith(Hero.GetRctangle()))
                    {
                        //如果成立则表明击中了英雄，英雄的生命值减少
                        Hero.Hp -= listEnemyZidan[i].Power;
                    this.Sore = Hero.Hp;
                        if (Hero.Hp <= 0)
                        {
                            SingleObject.GetSingle().Hero.IsOver();
                        this.f = 1;
                    }
                        listEnemyZidan.Remove(listEnemyZidan[i]);
                    break;
                    }
               


            }
        }

        //移除敌人飞机
        public void RemoveGameObject(GameObject go)
        {
            if (go is EnemyPlane)
            {
                this.ListEnemyPlane.Remove(go as EnemyPlane);
            }
            else if (go is HeroZidan)
            {
                this.ListHeroZidan.Remove(go as HeroZidan);
            }
            else if (go is EnemyZidan)
            {
                this.listEnemyZidan.Remove(go as EnemyZidan);
            }
        }

        //写一个函数，将函数的参数对象添加到游戏场景中
        public void AddGameObject(GameObject go)
        {
            if (go is Backround)
            {
                //如果传进来的参数是背景对象，则赋值给Backround的BG属性
                this.BG = go as Backround;
            }
            else if (go is HeroPlane)
            {
                this.Hero = go as HeroPlane;
            }
            else if (go is EnemyPlane)
            {
                this.ListEnemyPlane.Add(go as EnemyPlane);
            }
            else if (go is HeroZidan)
            {
                this.ListHeroZidan.Add(go as HeroZidan);
            }
            else if (go is EnemyZidan)
            {
                this.listEnemyZidan.Add(go as EnemyZidan);
            }
            
        }
        /// <summary>
        /// 将游戏对象绘制到窗体上
        /// </summary>
        /// <param name="g"></param>
        public void DrawGameObject(Graphics g)
        {
            this.BG.Draw(g);
            if (this.f == 0)
            {
                this.Hero.Draw(g);

            }
            for (int i = 0; i < ListEnemyPlane.Count; i++ )
            {


                    ListEnemyPlane[i].Draw(g);
                    
            }
            for (int i = 0; i < ListHeroZidan.Count; i++)
            {
                ListHeroZidan[i].Draw(g);
            }
            for (int i = 0; i < listEnemyZidan.Count; i++)
            {
                listEnemyZidan[i].Draw(g);
            }
        }
    }
}
