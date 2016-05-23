// Программа позволяет рисовать в форме графические примитивы:
// Выбор того или иного графического примитива
// осуществляется с помощью элемента управления ListBox
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
// Другие директивы using удалены, поскольку они не используются в данной
// программе
namespace РисФигур
{
    public partial class Form1 : Form
    {
        Object[] collection = new Object[] {"Окружность", "Треугольник", "Квадрат","Трапеция", "Эллипс" };

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = @"Выберите графический примитив";
            this.DoubleBuffered = true;
            listBox1.Visible = false;
            this.Size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            listBox1.Items.AddRange(collection);
            Font = new Font("Times New Roman", 12);
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Здесь вместо этого события можно было бы обработать также событие listBox1_Click.
            // Создание графического объекта
            var grafics = CreateGraphics();
            // Очистка области рисования путем ее окрашивания в первоначальный цвет формы
      //grafics.Clear(SystemColors.Control);
            switch (listBox1.SelectedIndex) // Выбор фигуры:
            {
                case 0:   // - выбрана окружность:
                     grafics.FillEllipse(new SolidBrush(Color.Chartreuse), MousePosition.X - 200, MousePosition.Y - 150, 150, 150); break;
                case 1:   // - выбран треугольник:
                    // Устанавливаем вершины треугольника:
                    var p1 = new Point(MousePosition.X + 50,  MousePosition.Y + 50);
                    var p2 = new Point(MousePosition.X + 225, MousePosition.Y + 66);
                    var p3 = new Point(MousePosition.X + 80,  MousePosition.Y + 185);
                    // Инициализируем массив точек:
                    Point[] points = { p1, p2, p3 };
                    // Закрашиваем этот треугольник цветом :
                    grafics.FillPolygon(new SolidBrush(Color.Aqua), points); break;
                case 2:   // - выбран квадрат:
                    grafics.FillRectangle(new SolidBrush(Color.Purple), MousePosition.X-220, MousePosition.Y-150, 150, 150); break;
                case 3:   // - выбрана трапеция:
                    grafics.FillPolygon(new SolidBrush(Color.BlueViolet), new[]{
                                            new Point(MousePosition.X + 100, MousePosition.Y + 20),
                                            new Point(MousePosition.X + 180, MousePosition.Y + 20),
                                            new Point(MousePosition.X + 260, MousePosition.Y + 130),
                                            new Point(MousePosition.X + 90, MousePosition.Y + 130)}); break;
                case 4:   // - выбран эллипс:
                    grafics.FillEllipse(new SolidBrush(Color.Red), MousePosition.X-220, MousePosition.Y - 150, 150, 200); break;
            }
            grafics.Dispose();
        }
        
        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == e.Button)
            {
                listBox1.Location = MousePosition;//ЛистБокс будет отображаться в том месте где будет кликнута мышка
                listBox1.Visible = true;
            }
        }
    }
}
