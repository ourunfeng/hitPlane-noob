using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form打飞机
{
    abstract class PlaneFather : GameObject
    {
        private Image imgPlane;//声明一个字段储存飞机的图片
        //构造函数
        public PlaneFather(int x, int y, Image img, int speed, int hp, Direction dir) : base(x, y, img.Width, img.Height, speed, hp, dir)
        {
            this.imgPlane = img;
        }

        public abstract void Fire();

        public abstract void IsOver();
        
    }
}
