using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Game_Escape_from_the_Room
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private static string name = MainWindow.Name;
        public GameWindow()
        {
            InitializeComponent();
            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            switch (str)
            {
                case "Открыть дверь": 
                    if(master_key) {
                        TextLabel.Text = $"Ура, {name}! Дверь поддалась, и вы уже чувствуете прохладный запах свободы.";
                        hiddenButton.Visibility = Visibility.Visible;
                    } else {
                        TextLabel.Text = "Вы дёргаете ручку, но дверь не открывается. Кто же тот негодяй, заперший вас здесь?";
                    } 
                    break;

                case "Заглянуть под кровать": 
                    if(bed) {
                        TextLabel.Text = "Пыль да одинокий красный паук.";
                    } else {
                        TextLabel.Text = $"О, кажется, вы что-то нашли! {name}, это какая-то сияющая фигня.";
                        bed = true;
                    }
                    break;

                case "Открыть ящик в углу комнаты": 
                    if (key) {
                        if(master_key) {
                            TextLabel.Text = "Сколько не смотри, а пустой ящик останется пустым.";
                        } else {
                            TextLabel.Text = $"С подозрением поглядывая на статую, вы подходите к ящику и пробуете открыть его найденным ключом. Так-с, что здесь?.. Эгей, {name}, да ведь это же отмычка!";
                            master_key = true;
                        }
                    } else {
                        TextLabel.Text = "Заперт, разумеется...";
                    }
                    break;

                case "Открыть вентиляцию": 
                    switch (vent) {
                        case 0: 
                            TextLabel.Text = "Боюсь, отскрести прибитую гвоздями решётку у вас не получится. Попробуйте выбить её.";
                            vent += 1;
                            break;
                        case 1: 
                            TextLabel.Text = "Второй раунд. Вентиляция отважно сопротивляется. Стоит показать ей коронный приём левой?";
                            vent += 1;
                            break;
                        case 2: 
                            TextLabel.Text = $"Я за вас болела, {name}! Просунув руку в вентиляцию, вы цепляете что-то мягкое и достаёте это вместе с клоками пыли.";
                            vent += 1;
                            break;
                        case 3: 
                            TextLabel.Text = "Не пытайтесь пролезть туда. Маловероятно, что с вашими габаритами, вы поместитесь..."; 
                            break;
                }
                    break;

                case "Взглянуть на тумбочку": 
                    if (table) {
                        TextLabel.Text = $"У вас совсем нет стыда, {name}. Стырили один артефакт и надеетесь заграбастать что-нибудь ещё.";
                    } else {
                        TextLabel.Text = $"Что это за безделушка, {name}? Вы ведь не возьмёте её себе?";
                        table = true;
                    }
                    break;

                case "Взглянуть на статую рядом с дверью": 
                    if (key) {
                        TextLabel.Text = "Когда вы смотрите на статую снова, вам кажется, что кончики её губ слегка приподнялись. Показалось? Хм, всё-таки стоит поскорее выбираться.";
                    } else if (bed && (vent == 3) && table) {
                        TextLabel.Text = "Осенённый озарением, вы складываете найденные безделушки в ладони статуи и шутливо кланяетесь, как вдруг... что-то щёлкает, и на вашу макушку падает маленький ключ.";
                        key = true;
                    } else {
                        TextLabel.Text = "Статуя безмолвно смотрит на вас, пока вы обходите её и проводите по ней руками, пытаясь нащупать тайник.";
                    }
                    break;

                case "Выйти из комнаты":
                    this.Close();
                    break;
            }
        }

        private static bool bed = false;
        private static int vent = 0;
        private static bool table = false;
        private static bool key = false;
        private static bool master_key = false;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
