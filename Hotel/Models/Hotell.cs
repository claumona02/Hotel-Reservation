using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Hotell
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string HotelName { get; set; }
        public string Adress { get; set; }
        public string HotelDetails
        {
            get
            {
                return HotelName + ""+Adress;} }
        [OneToMany]
 public List<ReservationList> ReservationLists { get; set; }
    }
}
