using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form打飞机.Properties;


namespace Form打飞机
{
    class EnemyZidan : ZiDan
    {
        public int ZidanType { get; set; }

        private static Image enemyZidan1 = Resources.zidan1;
        private static Image enemyZidan3 = Resources.enemyZidan3;
        public EnemyZidan(PlaneFather pf, int type) : base(pf, GetPower_WithZidan(type), GetZidan_WithType(type), pf.x + pf.Width / 2, pf.y+pf.Height, GetSpeed_WithZidan(type))
        {
            this.ZidanType = type;
        }

        public static Image GetZidan_WithType(int type)
        {
            if (type == 1 ||type == 2)
            {
                    return enemyZidan1;
            }
            else
            {
                return enemyZidan3;
            }
        }

        public static int GetSpeed_WithZidan(int Type)
        {
            switch (Type)
            {
                case 1:
                    return 6;
                case 2:
                    return 11;
                case 3:
                    return 5;
            }
            return 0;
        }

        public static int GetPower_WithZidan(int Type)
        {
            switch (Type)
            {
                case 1:
                    return 2;
                case 2:
                    return 1;
                case 3:
                    return 5;
            }
            return 0;

        }
    }
}
