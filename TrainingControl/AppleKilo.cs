using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrainingControl
{
    public class AppleKilo: INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public double ApplePrice { get { return applePrice; } set { applePrice = value; NotifyPropertyChanged(); }  } 
        public double GrowPrice { get; set; } = 15;
        public double Loss { get; set; }
        public double DeliveryPrice { get; set; } = 10;
        public double Profit { get { return profit; } set { profit = value;NotifyPropertyChanged(); } }

        private double applePrice = 0;
        private double profit = 0;
        public AppleKilo()
        {
            Id = new Guid();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double CountLoss()
        {
            Loss = GrowPrice + DeliveryPrice;
            return Loss;
        }

        public double CountProfit()
        {
            Profit = ApplePrice - Loss;
            return Profit;
        }

    }
}
