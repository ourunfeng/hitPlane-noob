using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form打飞机.Properties;

namespace Form打飞机
{
    class HeroZidan : ZiDan
    {
        private static Image heroZidan = Resources.zidan;
        public HeroZidan(PlaneFather pf, int speed, int power) : base(pf, power, heroZidan, pf.x + pf.Width/2-7, pf.y, speed)
        {
           
        }
      
    }
}
