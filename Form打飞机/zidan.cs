using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Form打飞机
{
    class ZiDan : GameObject
    {
        private Image ImgZidan;

        public int Power { get; set; }
        public ZiDan(PlaneFather pf,int power,Image img,int x, int y,int speed):base(x,y,img.Width,
            img.Height,speed,0,pf.Dir)
        {
            this.ImgZidan = img;
            this.Power = power;
        }
        public override void Draw(Graphics g)
        {
            
            base.Move();
            g.DrawImage(ImgZidan,this.x,this.y);
        }

        public override void MoveToBorder()
        {
            if (this.y <= 0 || this.y >= 850)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
            }
        }
    }
}
