using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MYinkscape
{
    public partial class Form1 : Form
    {
        class Vertex
        {
            public int name;
            public int x; // координаты
            public int y; // координаты

            public static int schetcik = 0;

            public Vertex(int xCons, int yCons)
            {
                schetcik++;
                name = schetcik;
                x = xCons;
                y = yCons;
            }
            public Vertex()
            {
            }
        }

        class Edge
        {
            public Vertex v1;
            public Vertex v2;
            public bool v1tov2;
            public bool v2tov1;
            public int cost;

            public Edge(Vertex v1Cons,Vertex v2Cons, bool v1tov2Cons, bool v2tov1Cons, int costCons)
            {
                v1 = v1Cons;
                v2 = v2Cons;
                v1tov2 = v1tov2Cons;
                v2tov1 = v2tov1Cons;
                cost = costCons;
            }
        }

        class Graph
        {
            public List<Vertex> VertexList;
            public List<Edge> EdgeList;
        }

        class VertexPair
        {
            public Vertex v1;
            public Vertex v2;

            public VertexPair(Vertex v1Cons, Vertex v2Cons)
            {
                v1 = v1Cons;
                v2 = v2Cons;
            }
        }

        string pathToFile = "C:\\roni\\laba_5.mdb";
        OleDbConnection conn = null;
        OleDbCommand cmd = null;

        static Graph graf;
        Vertex FirstVertexForEdge;
        Vertex selectedVertex;
        Edge selectedEdge;
        static int globalMin = 100000;
        static List<Vertex> minPyt = new List<Vertex>();

        class TreeNode
        {
            public List<Vertex> pyt;
            public List<TreeNode> strelki;
            public int totalCost;
            public bool stop;

            public TreeNode(List<Vertex> listCons, Vertex vCons, int totalCostCons)
            {
                pyt = new List<Vertex>(listCons); // конструктор создает копию списка listCons
                pyt.Add(vCons);
                strelki = new List<TreeNode>();
                totalCost = totalCostCons;

                IEnumerable<Vertex> distinctVertexes = pyt.Distinct(); // различные вершины
                int distinctVertexesCount = 0; //кол-во различных вершин
                foreach (Vertex v in distinctVertexes)// считает кол-во эл. в перечеслении distinctVertexes
                {
                    distinctVertexesCount++;
                }

                stop = false;
                if (distinctVertexesCount == graf.VertexList.Count)
                { 
                    stop = true;
                    if (totalCost < globalMin)
                    {
                        globalMin = totalCost;
                        minPyt = pyt;
                    }
                }
                if (totalCost >= globalMin) { stop = true; }
            }
        }

        public Form1()
        {
            InitializeComponent();//подготавливает компоненты(елементы управления)
            WindowState = FormWindowState.Maximized;//развернуть форму
            graf = new Graph();
            graf.VertexList = new List<Vertex>();
            graf.EdgeList = new List<Edge>();
            FirstVertexForEdge = new Vertex();
            FirstVertexForEdge = null;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;//работа с графикой GDI+
            g.Clear(Color.White);

            //выравнивание по центру
            StringFormat center = new StringFormat();//вся инфа о выравнивании
            center.Alignment = StringAlignment.Center; //ширина
            center.LineAlignment = StringAlignment.Center;//высота

            //вершины
            foreach(Vertex v in graf.VertexList)
            {
                g.DrawEllipse(new Pen(new SolidBrush(Color.LightGray), 2), v.x - 11, v.y - 11, 11 * 2, 11 * 2); 
            }
            foreach (Vertex v in graf.VertexList)
            {
                g.DrawString(v.name.ToString(), new Font("Arial", 12), new SolidBrush(Color.Black), v.x+1, v.y+1, center);
            }

            foreach (Edge e in graf.EdgeList)//ребра со стрелочками
            {
                Pen p = new Pen(new SolidBrush(Color.LightBlue), 2);
                AdjustableArrowCap myCap = new AdjustableArrowCap(2, 2) { WidthScale = 2, BaseCap = LineCap.Square, Height = 5 };
                if (e.v1tov2) { p.CustomEndCap = myCap; }
                if (e.v2tov1) { p.CustomStartCap = myCap; }
                g.DrawLine(p, e.v1.x, e.v1.y, e.v2.x, e.v2.y);
            }

            //ребра
            if (FirstVertexForEdge != null)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), FirstVertexForEdge.x - 11, FirstVertexForEdge.y - 11, 11 * 2, 11 * 2);
            }
            if (selectedVertex != null)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(128, 0, 255, 0)), selectedVertex.x - 11, selectedVertex.y - 11, 11 * 2, 11 * 2);
            }
            if (selectedEdge != null)
            {
                Pen p = new Pen(new SolidBrush(Color.Green), 2);
                AdjustableArrowCap myCap = new AdjustableArrowCap(2, 2); // наконечник стрелки
                myCap.WidthScale = 2;
                myCap.BaseCap = LineCap.Square;
                myCap.Height = 3;
                if (selectedEdge.v1tov2) { p.CustomEndCap = myCap; }
                if (selectedEdge.v2tov1) { p.CustomStartCap = myCap; }
                g.DrawLine(p, selectedEdge.v1.x, selectedEdge.v1.y, selectedEdge.v2.x, selectedEdge.v2.y);
            }

            //стоимость
            foreach(Edge e in graf.EdgeList)
            {
                int edgeCenterX = (e.v1.x + e.v2.x) / 2;
                int edgeCenterY = (e.v1.y + e.v2.y) / 2;
                g.FillRectangle(new SolidBrush(Color.White), edgeCenterX - 10, edgeCenterY - 8, 20, 16);
            }
            foreach (Edge e in graf.EdgeList)
            {
                int edgeCenterX = (e.v1.x + e.v2.x) / 2;
                int edgeCenterY = (e.v1.y + e.v2.y) / 2;
                g.DrawString(e.cost.ToString(), new Font("Arial", 12), new SolidBrush(Color.Blue), edgeCenterX + 1, edgeCenterY + 1, center);
            }

            //Список ребер
            richTextBox1.Text = "Список ребер: \n";
            foreach (Edge e in graf.EdgeList)
            {
                richTextBox1.Text += e.v1.name.ToString() + " - " + e.v2.name.ToString() + "\n";
            }

            // Список суміжності
            richTextBox2.Text = "Список суміжності: \n";
            foreach (Vertex v in graf.VertexList)
            {
                richTextBox2.Text += v.name.ToString() + "->";
                foreach (Edge ee in graf.EdgeList)
                {
                    if (ee.v1 == v && ee.v1tov2 == true)
                    {
                        richTextBox2.Text += ee.v2.name.ToString() + "; ";
                    }
                    if (ee.v2 == v && ee.v2tov1 == true)
                    {
                        richTextBox2.Text += ee.v1.name.ToString() + "; ";
                    }
                }
                richTextBox2.Text += "\n";
            }

            // Таблица сумижности
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < graf.VertexList.Count; i++)
            {
                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns[i].HeaderText = graf.VertexList[i].name.ToString();
                dataGridView1.Columns[i].Name = graf.VertexList[i].name.ToString();
                dataGridView1.Columns[i].Width = 28;
            }
            for (int i = 0; i < graf.VertexList.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = graf.VertexList[i].name.ToString();
            }
            foreach (Edge ee in graf.EdgeList)
            {
                int index_v1 = 0;
                int index_v2 = 0;
                if (ee.v1tov2)
                {
                    index_v1 = 0;
                    index_v2 = 0;
                    foreach (Vertex v in graf.VertexList)
                    {
                        if (v == ee.v1) { break; }
                        index_v1++;
                    }
                    foreach (Vertex v in graf.VertexList)
                    {
                        if (v == ee.v2) { break; }
                        index_v2++;
                    }
                    dataGridView1.Rows[index_v1].Cells[index_v2].Value = CheckState.Checked;
                }
                if (ee.v2tov1)
                {
                    index_v1 = 0;
                    index_v2 = 0;
                    foreach (Vertex v in graf.VertexList)
                    {
                        if (v == ee.v1) { break; }
                        index_v1++;
                    }
                    foreach (Vertex v in graf.VertexList)
                    {
                        if (v == ee.v2) { break; }
                        index_v2++;
                    }
                    dataGridView1.Rows[index_v2].Cells[index_v1].Value = CheckState.Checked;
                }
            }

        }
        
        private void Form1_MouseClick(object sender, MouseEventArgs mouse)
        {
            //вершина
            if (VertexButton.Checked == true)
            {
                graf.VertexList.Add(new Vertex(mouse.X, mouse.Y));
                Invalidate();
            }
            //одностороннее ребро
            if (EdgeOneWayButton.Checked == true)
            {
                if (FirstVertexForEdge == null)
                {
                    foreach (Vertex v in graf.VertexList)
                    {
                        if ((v.x - mouse.X) * (v.x - mouse.X) + (v.y - mouse.Y) * (v.y - mouse.Y) <= 11 * 11)
                        {
                            FirstVertexForEdge = v;
                            Invalidate();
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Vertex v in graf.VertexList)
                    {
                        if ((v.x - mouse.X) * (v.x - mouse.X) + (v.y - mouse.Y) * (v.y - mouse.Y) <= 11 * 11 && v != FirstVertexForEdge)
                        {
                            graf.EdgeList.Add(new Edge(FirstVertexForEdge, v, true, false, Convert.ToInt32(EdgeCostTextBox.Text)));
                            FirstVertexForEdge = null;
                            Invalidate();
                            break;
                        }
                    }
                }
            }

            //двухстороннее ребро
            if (EdgeTwoWayButton.Checked == true)
            {
                if (FirstVertexForEdge == null)
                {
                    foreach (Vertex v in graf.VertexList)
                    {
                        if ((v.x - mouse.X) * (v.x - mouse.X) + (v.y - mouse.Y) * (v.y - mouse.Y) <= 11 * 11)
                        {
                            FirstVertexForEdge = v;
                            Invalidate();
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Vertex v in graf.VertexList)
                    {
                        if ((v.x - mouse.X) * (v.x - mouse.X) + (v.y - mouse.Y) * (v.y - mouse.Y) <= 11 * 11 && v != FirstVertexForEdge)
                        {
                            graf.EdgeList.Add(new Edge(FirstVertexForEdge, v, true, true, Convert.ToInt32(EdgeCostTextBox.Text)));
                            FirstVertexForEdge = null;
                            Invalidate();
                            break;
                        }
                    }
                }
            }
            //выделение
            if (SelectButton.Checked == true)
            {
                FirstVertexForEdge = null;
                selectedVertex = null;
                selectedEdge = null;
                //выделяем вершину
                foreach (Vertex v in graf.VertexList)
                {
                    if ((v.x - mouse.X) * (v.x - mouse.X) + (v.y - mouse.Y) * (v.y - mouse.Y) <= 11 * 11)
                    {
                        selectedVertex = v;
                        break;
                    }
                };
                // может попали на ребро
                if (selectedVertex == null)
                {
                    int x1, x2, x, y1, y2, y;
                    x = mouse.X;
                    y = mouse.Y;
                    foreach (Edge e in graf.EdgeList)
                    {
                        x1 = e.v1.x;
                        y1 = e.v1.y;
                        x2 = e.v2.x;
                        y2 = e.v2.y;
                        if (((x1 - x) * (x1 - x2) + (y1 - y) * (y1 - y2) > 0)
                           && ((x2 - x1) * (x2 - x) + (y2 - y1) * (y2 - y) > 0))
                        {
                            int A = y1 - y2;
                            int B = x2 - x1;
                            int C = x1 * (y2 - y1) - y1 * (x2 - x1);
                            if (Math.Abs((A * x + B * y + C) / Math.Sqrt(A * A + B * B)) < 11)
                            {
                                selectedEdge = e;
                                break;
                            }
                        }
                    }
                }
                Invalidate();
            }
        }

        private void VertexButton_Click(object sender, EventArgs e)
        {
            if (VertexButton.Checked == false)
            {
                VertexButton.Checked = true;
                EdgeOneWayButton.Checked = false;
                EdgeTwoWayButton.Checked = false;
                SelectButton.Checked = false;
            }
            else
            {
                VertexButton.Checked = false;
            }
        }

        private void EdgeOneWayButton_Click(object sender, EventArgs e)
        {
            if (EdgeOneWayButton.Checked == false)
            {
                EdgeOneWayButton.Checked = true;
                VertexButton.Checked = false;
                EdgeTwoWayButton.Checked = false;
                SelectButton.Checked = false;
            }
            else
            {
                EdgeOneWayButton.Checked = false;
            }
        }

        private void EdgeTwoWayButton_Click(object sender, EventArgs e)
        {
            if (EdgeTwoWayButton.Checked == false)
            {
                EdgeTwoWayButton.Checked = true;
                VertexButton.Checked = false;
                EdgeOneWayButton.Checked = false;
                SelectButton.Checked = false;
            }
            else
            {
                EdgeTwoWayButton.Checked = false;
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (SelectButton.Checked == false)
            {
                SelectButton.Checked = true;
                VertexButton.Checked = false;
                EdgeOneWayButton.Checked = false;
                EdgeTwoWayButton.Checked = false;
            }
            else
            {
                SelectButton.Checked = false;
            }
        }

        private void DiameterButton_Click(object sender, EventArgs Args)
        {
            Vertex activeVertex = new Vertex();
            int beskonechnost = 100000;
            int min = beskonechnost;
            int globalMax = -1;
            List<VertexPair> MaxVertexPairList = new List<VertexPair>();
            Dictionary<Vertex, int> metochki = new Dictionary<Vertex, int>(graf.VertexList.Count); // асоциативный масив меток
            Dictionary<Vertex, bool> on = new Dictionary<Vertex,bool>(graf.VertexList.Count);// асоциативный масив живой/не живой
            int lifeCount = graf.VertexList.Count; // все живые

            foreach (Vertex v in graf.VertexList)
            {
                lifeCount = graf.VertexList.Count;
                activeVertex = v;
                metochki[v] = 0;
                foreach (Vertex vv in graf.VertexList)
                {
                    if (vv != v)
                    {
                        metochki[vv] = beskonechnost;
                    }

                    on[vv] = true; // присваивает сначала всем вершинам что они есть в графе
                }

                while (lifeCount > 0)
                {
                    //активная вершина
                    min = beskonechnost;
                    foreach (Vertex vv in graf.VertexList)
                    {
                        if (on[vv] == true && metochki[vv] < min)
                        {
                            activeVertex = vv;
                            min = metochki[vv];
                        }
                    }

                    // перебрали все возможные пути и обновили меточки
                    foreach (Edge e in graf.EdgeList)
                    {
                        if (e.v1 == activeVertex && e.v1tov2 == true && on[e.v2] == true)
                        {
                            if (metochki[activeVertex] + e.cost < metochki[e.v2])
                            {
                                metochki[e.v2] = metochki[activeVertex] + e.cost;
                            }
                        }
                        if (e.v2 == activeVertex && e.v2tov1 == true && on[e.v1] == true)
                        {
                            if (metochki[activeVertex] + e.cost < metochki[e.v1])
                            {
                                metochki[e.v1] = metochki[activeVertex] + e.cost;
                            }
                        }
                    }

                    //зачеркнули активную вершину
                    on[activeVertex] = false;
                    lifeCount--;
                }

                //смотрит результаты для конкретной вершины на максимум
                foreach (Vertex vv in graf.VertexList)
                {
                    if (metochki[vv] > globalMax)
                    {
                        MaxVertexPairList.Clear();
                        globalMax = metochki[vv];
                        MaxVertexPairList.Add(new VertexPair(v, vv));
                    }
                    else if (metochki[vv] == globalMax)
                    {
                        MaxVertexPairList.Add(new VertexPair(v, vv));
                    }
                }

            }

            string s = "";
            foreach(VertexPair vp in MaxVertexPairList)
            {
                s += vp.v1.name.ToString() + " - " + vp.v2.name.ToString() + "\n";
            }

            MessageBox.Show("Диаметр графа = " + globalMax + "\nПары:\n" + s);
        }

        void down(TreeNode t, int level) // пробуривает 1 уровень вниз
        {
            if (level == 0 && t.stop == false) // роем новый уровень
            {
                foreach (Edge e in graf.EdgeList)
                {
                    if (e.v1 == t.pyt[t.pyt.Count - 1] && e.v1tov2 == true)
                    {
                        TreeNode vetka = new TreeNode(t.pyt, e.v2, e.cost + t.totalCost);
                        t.strelki.Add(vetka);
                    }
                    else if (e.v2 == t.pyt[t.pyt.Count - 1] && e.v2tov1 == true)
                    {
                        TreeNode vetka = new TreeNode(t.pyt, e.v1, e.cost + t.totalCost);
                        t.strelki.Add(vetka);
                    }
                }
            }
            else // погружаемся до нужного (нижнего)
            {
                foreach (TreeNode child in t.strelki)
                {
                    if (t.stop == false)
                    {
                        down(child, level - 1);
                    }
                }
            }
        }

        private void MinPathButton_Click(object sender, EventArgs Args)
        {
            TreeNode zero = new TreeNode(new List<Vertex>(),new Vertex(), 0); // нулевая
            foreach (Vertex v in graf.VertexList)
            {
                zero.strelki.Add(new TreeNode(new List<Vertex>(), v, 0)); // 0 -> 1, 2, 3 создаем стрелку и сразу обьект на который она указывает
            }

            for (int level = 1; level < Math.Min(12, 2 * graf.VertexList.Count); level++)
            {
                down(zero, level);
            }

            string s = "";
            foreach (Vertex v in minPyt)
            {
                s += v.name.ToString() + " - "; 
            }
            s = s.Substring(0, s.Length - 3);
            MessageBox.Show("Минимальная стоимость:" + "\n" + globalMin.ToString() + "\n" + s);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedVertex != null)
            {
                /*foreach (Edge ee in ed)
                {
                    if ((ee.v1 == selectedVertex) || (ee.v2 == selectedVertex)) { ed.Remove(ee); }
                }*/
                graf.VertexList.Remove(selectedVertex);
                selectedVertex = null;
            }
            if (selectedEdge != null)
            {
                graf.EdgeList.Remove(selectedEdge);
                selectedEdge = null;
            }
            Invalidate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            graf.VertexList.Clear();
            graf.EdgeList.Clear();
            Vertex.schetcik = 0;
            Invalidate();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Щоб видалити вершину, спочатку треба видалити всі пов’язані з нею ребра.\n" +
                "Забороняється малювати ребро поверх існуючого(не важливо одно- чи двонаправлене).\n" +
                "Таблиця суміжності, список суміжності та список ребер – виводяться автоматично при малюванні графа.\n" +
                "Щоб вивести діаметр або мінімальний шлях потрібно натиснути на відповідні кнопки.\n" +
                "Якщо не зрозуміло функціонал кнопки по зовнішньому вигляду, то можна навести курсор на відповідну кнопку і у ви падаючій підказці буде пояснення.\n" +
                "Активна вершина чи ребро підсвічується зеленим кольором (при додаванні ребер, чи при видаленні вершин чи ребер)");
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лабораторну роботу виконував студент 2го курсу, факультету Кібенетики, групи К-26, Врабець Володимир!!!");
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            pathToFile = dlg.FileName;
            if (pathToFile != "")
            {
                Vertex.schetcik = 0;
                graf.VertexList.Clear();
                graf.EdgeList.Clear();
                string connString = @"
                Provider = Microsoft.Jet.OLEDB.4.0;
                Data Source=" + pathToFile + @";
                User Id=admin; Password=;
                ";

                conn = new OleDbConnection(connString);
                conn.Open();

                //Vertex
                string select = @"
                Select * 
                From Vertex;
                ";
                cmd = new OleDbCommand(select, conn);

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    graf.VertexList.Add(new Vertex(Convert.ToInt32(reader["x"]), Convert.ToInt32(reader["y"])));
                }

                //Edge
                select = @"
                Select * 
                From Edge;
                ";
                cmd = new OleDbCommand(select, conn);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vertex v1 = null;
                    foreach (Vertex vv in graf.VertexList)
                    {
                        if (reader["label1"].ToString() == vv.name.ToString())
                        {
                            v1 = vv; break;
                        }
                    }

                    Vertex v2 = null;
                    foreach (Vertex vv in graf.VertexList)
                    {
                        if (reader["label2"].ToString() == vv.name.ToString())
                        {
                            v2 = vv; break;
                        }
                    }

                    graf.EdgeList.Add(new Edge(v1, v2,Convert.ToBoolean(reader["v1_v2"]), Convert.ToBoolean(reader["v2_v1"]), Convert.ToInt32(reader["cost"])));
                }
            }
            Invalidate();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connString = @"
                Provider = Microsoft.Jet.OLEDB.4.0;
                Data Source=" + pathToFile + @";
                User Id=admin; Password=;
                ";

            conn = new OleDbConnection(connString);
            conn.Open();

            //Vertex
            string delete = @"
            Delete From Vertex;
            ";
            cmd = new OleDbCommand(delete, conn);
            cmd.ExecuteNonQuery();

            string ins = @"
            Insert Into
                Vertex (label, x, y, colorR, colorG, colorB)
            Values
                (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6);
            ";
            cmd = new OleDbCommand(ins, conn);
            foreach (Vertex vv in graf.VertexList)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Value1", OleDbType.VarChar, 50).Value = vv.name.ToString();
                cmd.Parameters.Add("@Value2", OleDbType.Integer).Value = vv.x;
                cmd.Parameters.Add("@Value3", OleDbType.Integer).Value = vv.y;
                cmd.Parameters.Add("@Value4", OleDbType.Integer).Value = 0;
                cmd.Parameters.Add("@Value5", OleDbType.Integer).Value = 0;
                cmd.Parameters.Add("@Value6", OleDbType.Integer).Value = 0;
                cmd.ExecuteNonQuery();
            }

            //Edge
            delete = @"
            Delete From Edge;
            ";
            cmd = new OleDbCommand(delete, conn);
            cmd.ExecuteNonQuery();

            ins = @"
            Insert Into
                Edge (label1, label2, colorR, colorG, colorB, cost, v1_v2, v2_v1)
            Values
                (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8);
            ";
            cmd = new OleDbCommand(ins, conn);
            foreach (Edge ee in graf.EdgeList)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@Value1", OleDbType.VarChar, 50).Value = ee.v1.name.ToString();
                cmd.Parameters.Add("@Value2", OleDbType.VarChar, 50).Value = ee.v2.name.ToString();
                cmd.Parameters.Add("@Value3", OleDbType.Integer).Value = 0;
                cmd.Parameters.Add("@Value4", OleDbType.Integer).Value = 0;
                cmd.Parameters.Add("@Value5", OleDbType.Integer).Value = 0;
                cmd.Parameters.Add("@Value6", OleDbType.Integer).Value = ee.cost;
                cmd.Parameters.Add("@Value7", OleDbType.Boolean).Value = ee.v1tov2;
                cmd.Parameters.Add("@Value8", OleDbType.Boolean).Value = ee.v2tov1;
                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Saved succesfull!");
        }

        
    }
}
