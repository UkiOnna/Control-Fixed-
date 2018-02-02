using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace TrainingControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<AppleKilo> apples;
        private XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<AppleKilo>));
        public MainWindow()
        {
            InitializeComponent();

            apples = new ObservableCollection<AppleKilo>
            {
            new AppleKilo { Id=new Guid(),  ApplePrice = 0, City = "Астана", DeliveryPrice = 10, GrowPrice = 10 },
            new AppleKilo {Id=new Guid(), ApplePrice = 0, City = "Уральск", DeliveryPrice = 20, GrowPrice = 30 },
            new AppleKilo { Id=new Guid(),ApplePrice = 0, City = "Иркутск", DeliveryPrice = 50, GrowPrice = 10 }
            };
            //using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + @"\data.xml", FileMode.OpenOrCreate))
            //{
            //    apples = serializer.Deserialize(stream) as ObservableCollection<AppleKilo>;
            //}
            AppleContainer.ItemsSource = apples;
            AppleContainer.CellEditEnding += new EventHandler<DataGridCellEditEndingEventArgs>(AppleContainerCellEditEnding);
           // AppleContainer.TouchEnter += new EventHandler<TouchEventArgs>(AppleContainer_TouchEnter);
        }



        private void AppleContainerCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //IList rows = AppleContainer.SelectedItems;
            //DataRowView row = (DataRowView)AppleContainer.SelectedItems[0];
            //MessageBox.Show(  row[1].ToString());
         


            using (FileStream stream = new FileStream(Directory.GetCurrentDirectory() + @"\data.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, apples);
            }
        }

        private void AppleContainerCurrentCellChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < apples.Count; i++)
            {

                if (apples[i].ApplePrice != 0 && apples[i].ApplePrice != null)
                {
                    apples[i].CountLoss();
                    apples[i].CountProfit();
                }
                

            }
        }

        private void AppleContainer_TouchEnter(object sender, TouchEventArgs e)
        {
          
        }
    }
}
