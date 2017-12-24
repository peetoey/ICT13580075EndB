using ICT13580075EndB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICT13580075EndB.Helpers
{
    public class DbHelper
    {
        SQLiteConnection db;
        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Car>();
        }
        public int AddCar(Car car)
        {
            db.Insert(car);
            return car.Id;
        }
        public List<Car> GetCar()
        {
            return db.Table<Car>().ToList();
        }
        public int UpdateCar(Car car)
        {
            return db.Update(car);
        }
        public int DeleteCar(Car car)
        {
            return db.Delete(car);
        }
    }
}

