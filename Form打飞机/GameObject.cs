using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form打飞机
{
    //方向枚举值
    enum Direction
    {
        up,
        donwm,
        left,
        right
    }

    /// <summary>
    /// 这是所有游戏对象的父类，封装所有子类所共有的成员
    /// </summary>
    abstract class GameObject


    {
        #region 属性成员（横纵坐标，宽度，高度，速度，生命值，方向）;
        //游戏对象的X坐标
        public int x
        {
            get;
            set;
        }
        //游戏对象的Y坐标
        public int y
        {
            get;
            set;
        }
        //游戏对象的宽度
        public int Width
        {
            get;
            set;
        }
        //游戏对象的高度
        public int Height
        {
            get;
            set;
        }
        //游戏对象的速度
        public int Speed
        {
            get;
            set;
        }
        //游戏对象的生命值
        public int Hp
        {
            get;
            set;
        }
        //游戏对象的方向
        public Direction Dir
        {
            get;
            set;
        }
        #endregion
        /// <summary>
        /// 父类构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="hight"></param>
        /// <param name="speed"></param>
        /// <param name="hp"></param>
        /// <param name="dir"></param>
        public GameObject(int x, int y, int width, int hight, int speed, int hp, Direction dir)
        {
            this.x = x;
            this.y = y;
            this.Width = width;
            this.Height = hight;
            this.Speed = speed;
            this.Hp = hp;
            this.Dir = dir;

        }


        /// <summary>
        /// 游戏对象移动的方法
        /// </summary>
        public virtual void Move()
        {
            //根据当前的方向移动
            switch (this.Dir)
            {
                case Direction.up:
                    this.y -= this.Speed;
                    break;
                case Direction.donwm:
                    this.y += this.Speed;
                    break;
                case Direction.left:
                    this.x -= this.Speed;
                    break;
                case Direction.right:
                    this.x += this.Speed;
                    break;
                default:
                    break;
            }

        }



        //每个函数对象在使用GUI+对象绘制自己的窗体的时候，绘制的方式都各不一样。
        //所以我们需要父类中提供一个绘制对象的抽象函数。
        /// <summary>
        /// 绘制游戏对象的方法
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);

        /// <summary>
        /// 当游戏对象移动到边缘的时候，对对象的一个处理方式
        /// </summary>
        public abstract void MoveToBorder();

        /// <summary>
        /// 获得当前游戏对象所在的矩形位置，用于碰撞检测
        /// </summary>
        public Rectangle GetRctangle()
        {
            return new Rectangle(this.x, this.y, this.Width, this.Height);
        }
    }



}
