using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form打飞机.Properties;

namespace Form打飞机
{
     class Backround : GameObject
    {
        //首先将背景图片导入，因为我们需要把背景图片绘制到窗体上
        private static Image img = Resources.BackGround;

        //调用父类的构造函数
        public Backround(int x, int y,int speed) : base(x, y, img.Width, img.Height, speed, 0, Direction.donwm)
        {

        }

        public override void Draw(Graphics g)
        {
            this.y += this.Speed;
            if (this.y >= 0)
            {
                this.y = -850;
            }
            //坐标改变完成后，将背景图像不停地绘制在我们的窗体中
            g.DrawImage(Resources.BackGround, this.x, this.y);
        }

        public override void MoveToBorder()
        {
            
            
        }
    }
}
