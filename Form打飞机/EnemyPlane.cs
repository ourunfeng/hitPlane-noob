using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form打飞机.Properties;


namespace Form打飞机
{
   class EnemyPlane : PlaneFather
    {
        private static Image Enemy1 = Resources.Enemy1;
        private static Image Enemy2 = Resources.Enemy2;
        private static Image Enemy3 = Resources.Enemy3;

        public EnemyPlane(int x,int y,int PlaneType) : base(x, y, GetImageType(PlaneType),
           GetSpeed_PlaneType(PlaneType), GetHp_PlaneType(PlaneType),Direction.donwm)
        {
            this.PlaneType = PlaneType;
        }
        
        public override void Draw(Graphics g)
        {
            this.Move();
            this.MoveToBorder();
            //根据当前飞机的类型绘制的图片
            switch (this.PlaneType)
            {
                case 1:
                    g.DrawImage(Enemy1, this.x, this.y);
                    break;
                case 2:
                    g.DrawImage(Enemy2, this.x, this.y);
                    break;
                case 3:
                    g.DrawImage(Enemy3, this.x, this.y);
                    break;

            }
            if (r.Next(0,100)>95)
            {
                this.Fire();

            }


        }
        //Random r = new Random((int)DateTime.Now.Ticks);
        Random r = new Random();
        public override void MoveToBorder()
        {
            Random k = new Random();

            //坐标修正
            if (this.y>= 850-this.Height)
            {
                //将敌人的飞机对象销毁
                SingleObject.GetSingle().RemoveGameObject(this);
            }
            if (this.x <= 0)
            {
                this.x = 0;
            }
            if (this.x >= 440 - this.Width)
            {
                this.x = 440 - this.Width;
            }
            if (this.PlaneType == 2 && this.y >= 0)
            {
                int s = k.Next(1, 101);
                if (this.x >= 0 && s > 50)
                {
                    this.x -= 0 + r.Next(3, 120);
                }
                else
                {
                    this.x += 0 + r.Next(3, 120);
                }
            }
            else if (this.PlaneType == 1 && this.y >= 0)
            {
                int s = k.Next(1, 101);
                if (this.x >= 0 && s > 50)
                {
                    this.x -= 0 + r.Next(3, 100);
                }
                else
                {
                    this.x += 0 + r.Next(3, 100);
                }
            }
            else if (this.PlaneType == 3 && this.y <= 200)
            {
                int s = k.Next(1, 101);
                if (this.x >= 0 && s > 50)
                {
                    this.x -= 0 + r.Next(30, 150);
                }
                else
                {
                    this.x += 0 + r.Next(30, 150);
                }
            }
        }

        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZidan(this,this.PlaneType)) ;
        }

        //飞机的类型 1 2 3
        public int PlaneType { get; set; }

        /// <summary>
        ///  判断飞机的类型，返回不同的飞机图片
        /// </summary>
        /// <param name="PlaneType">飞机的类型</param>
        /// <returns></returns>
        public static Image GetImageType (int PlaneType)
        {
            switch (PlaneType)
            {
                case 1:
                    return Enemy1;
                case 2:
                    return Enemy2;
                case 3:
                    return Enemy3;
            }
                return null;
        }
        /// <summary>
        ///  判断飞机的类型，返回不同的飞机血量
        /// </summary>
        /// <param name="PlaneType"></param>
        /// <returns></returns>
        public static int GetHp_PlaneType (int PlaneType)
        {
            switch (PlaneType)
            {
                case 1:
                    return 12;
                case 2:
                    return 7;
                case 3:
                    return 30;
            }
            return 0;
        }
        /// <summary>
        /// 判断飞机的类型，返回不同的飞机速度
        /// </summary>
        /// <param name="PlaneType"></param>
        /// <returns></returns>
        public static int GetSpeed_PlaneType(int PlaneType)
        {
            switch (PlaneType)
            {
                case 1:
                    return 4;
                case 2:
                    return 7;
                case 3:
                    return 2;
            }
            return 0;
        }

        public override void IsOver()
        {
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
