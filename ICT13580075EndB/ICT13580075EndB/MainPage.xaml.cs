using ICT13580075EndB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580075EndB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;

        }
        protected override void OnAppearing()
        {
            LoadData();
        }
        void LoadData()
        {
            carListview.ItemsSource = App.DbHelper.GetCar();
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CarNewPage());
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var car = button.CommandParameter as Car;
            Navigation.PushModalAsync(new CarNewPage(car));
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                var button = sender as MenuItem;
                var car = button.CommandParameter as Car;
                App.DbHelper.DeleteCar(car);

                await DisplayAlert("ลบสำเร็จ", "ลบข้อมูลรถยนต์เรียบร้อย", "ตกลง");
                LoadData();
            }
        }
    }
}