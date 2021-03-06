using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form打飞机.Properties;
/// <summary>
/// 玩家飞机类
/// </summary>
namespace Form打飞机
{
     class HeroPlane : PlaneFather
    {
        private static Image imgHero = Properties.Resources.Hero1;//玩家的飞机
        public HeroPlane(int x, int y, int speed, int hp, Direction dir) : base(x, y, imgHero, speed, hp, dir)
        {
            
        }
        public override void Draw(Graphics g)
        {
            this.MoveToBorder();  //画的过程中不停地判断这个坐标是否超出了界限
            g.DrawImage(imgHero,this.x,this.y,this.Width,this.Height);
            // 扩大图像（增加图像宽高）
            //g.DrawImage(imgHero,this.x,this.y,this.Width*2,this.Height*2);   

        }

        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new HeroZidan(this, 20, 3));
        }

        public override void MoveToBorder()
        {
            if (this.x <= 0)
            {
                this.x = 0;
            }
            if (this.x >= 480 - this.Width)
            {
                this.x = 410;
            }
            if (this.y <=0)
            {
                this.y = 0;
            }
            if (this.y >= 710)
            {
                this.y = 710;
            }
        }

        //鼠标移动
        public void MoveWithMouse(MouseEventArgs e)
        {
            this.x = e.X;
            this.y = e.Y;
            
        }

        public override void IsOver()
        {
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
