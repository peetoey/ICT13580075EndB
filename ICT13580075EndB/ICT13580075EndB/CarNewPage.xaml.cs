using ICT13580075EndB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580075EndB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarNewPage : ContentPage
    {
        Car car;
        int yearValue, mileValue;
        String dealer;

        public CarNewPage(Car car = null)
        {
            InitializeComponent();
            this.car = car;


            titleLabel.Text = car == null ? "เพิ่มรถยนต์ใหม่" : "แก้ไขข้อมูลรถยนต์";

            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            yearStepper.ValueChanged += yearStepper_ValueChanged;
            mileSlider.ValueChanged += mileSlider_ValueChanged;
            dealerSwitch.Toggled += DealerSwitch_Toggled;

            typePicker.Items.Add("รถเก๋ง");
            typePicker.Items.Add("รถกระบะ");
            typePicker.Items.Add("รถบรรทุก");
            typePicker.Items.Add("รถตู้");
            typePicker.Items.Add("รถขายไอติม");

            brandPicker.Items.Add("Toyota");
            brandPicker.Items.Add("Honda");
            brandPicker.Items.Add("Nissan");
            brandPicker.Items.Add("Mitsubishi");

            colorPicker.Items.Add("ขาว");
            colorPicker.Items.Add("ดำ");
            colorPicker.Items.Add("แดง");
            colorPicker.Items.Add("เทา");
            colorPicker.Items.Add("ฟ้า");

            cityPicker.Items.Add("กรุงเทพฯ");
            cityPicker.Items.Add("เพชรบุรี");
            cityPicker.Items.Add("สมุทรสาคร");
            cityPicker.Items.Add("เชียงใหม่");
            cityPicker.Items.Add("ภูเก็ต");

            if (car != null)
            {


                typePicker.SelectedItem = car.Type;
                brandPicker.SelectedItem = car.Brand;
                genEntry.Text = car.Gen;
                colorPicker.SelectedItem = car.Color;
                detailEditor.Text = car.Detail;
                priceEntry.Text = car.Price.ToString();
                cityPicker.SelectedItem = car.City;
                phoneEntry.Text = car.Phone;





            }
        }

        private void DealerSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                dealer = "ใช่";
            }
            else
            {
                dealer = "ไม่ใช่";
            }

        }

        private void mileSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            mile.Text = value.ToString();
            mileValue = value;
        }

        private void yearStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            year.Text = value.ToString();
            yearValue = value;
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (car == null)
                {
                    car = new Car();
                    car.Type = typePicker.SelectedItem.ToString();
                    car.Brand = brandPicker.SelectedItem.ToString();
                    car.Gen = genEntry.Text;
                    car.Year = yearValue;
                    car.Mile = mileValue;
                    car.Color = colorPicker.SelectedItem.ToString();
                    car.Dealer = dealer;
                    car.Detail = detailEditor.Text;
                    car.Price = decimal.Parse(priceEntry.Text);
                    car.City = cityPicker.SelectedItem.ToString();
                    car.Price = decimal.Parse(priceEntry.Text);
                    car.Phone = phoneEntry.Text;

                    var id = App.DbHelper.AddCar(car);
                    await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }
                else
                {
                    car.Type = typePicker.SelectedItem.ToString();
                    car.Brand = brandPicker.SelectedItem.ToString();
                    car.Gen = genEntry.Text;
                    car.Year = yearValue;
                    car.Mile = mileValue;
                    car.Color = colorPicker.SelectedItem.ToString();
                    car.Dealer = dealer;
                    car.Detail = detailEditor.Text;
                    car.Price = decimal.Parse(priceEntry.Text);
                    car.City = cityPicker.SelectedItem.ToString();
                    car.Price = decimal.Parse(priceEntry.Text);
                    car.Phone = phoneEntry.Text;

                    var id = App.DbHelper.UpdateCar(car);
                    await DisplayAlert("แก้ไขสำเร็จ", "แก้ไขข้อมูลรถยนต์หมายเลข #" + id + " เรียบร้อย", "ตกลง");

                }
                await Navigation.PopModalAsync();
            }

        }
    }
}