using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form打飞机
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialGame();
            
        }
        Random r = new Random();
        /// <summary>
        /// 初始化游戏对象
        /// </summary>
        private void InitialGame()
        {
            //初始化背景对象
            SingleObject.GetSingle().AddGameObject(new Backround(0, -850, 15));
            //初始化玩家对象

            SingleObject.GetSingle().AddGameObject(new HeroPlane(200,650,20,15,Direction.up));
            Invali_EnemyPlane();
        }
        //窗体被重绘的时候会执行这个事件
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          SingleObject.GetSingle().DrawGameObject(e.Graphics);
            string s = SingleObject.GetSingle().Sore.ToString();
            e.Graphics.DrawString(s, new Font("微软雅黑",20,FontStyle.Bold), Brushes.Red, new Point(4, 4));
        }
        /// <summary>
        /// 初始化飞机对象
        /// </summary>
        private void Invali_EnemyPlane()
        {
            for (int i = 0; i < 4; i++)
            {
     
                    SingleObject.GetSingle().AddGameObject(new EnemyPlane(r.Next(0, this.Width), -100, r.Next(1, 3)));
                    
         

            }
            //母舰出现概率
            if (30 > r.Next(1, 101))
            {
                SingleObject.GetSingle().AddGameObject(new EnemyPlane(r.Next(0, this.Width), -100, 3));

            }

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            if (SingleObject.GetSingle().ListEnemyPlane.Count <= 1)
            {
                Invali_EnemyPlane();
            }
            SingleObject.GetSingle().PZJC();
            
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            
                SingleObject.GetSingle().Hero.MoveWithMouse(e);

            
            

            //将鼠标的坐标赋值给玩家飞机的坐标
        }

        /// <summary>
        /// 玩家发射子弹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //点击鼠标左键
            if (e.Button == MouseButtons.Left)
            {
                SingleObject.GetSingle().Hero.Fire();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
