using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;
using SQLite;

namespace Hotel.Data
{
    public class ReservationListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ReservationListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ReservationList>().Wait();
            _database.CreateTableAsync<Room>().Wait();
            _database.CreateTableAsync<ListRoom>().Wait();
            _database.CreateTableAsync<Hotell>().Wait();

        }
        public Task<List<ReservationList>> GetReservationListsAsync()
        {
            return _database.Table<ReservationList>().ToListAsync();
        }
        public Task<ReservationList> GetReservationListAsync(int id)
        {
            return _database.Table<ReservationList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveReservationListAsync(ReservationList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteReservationListAsync(ReservationList slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveRoomAsync(Room room)
        {
            if (room.ID != 0)
            {
                return _database.UpdateAsync(room);
            }
            else
            {
                return _database.InsertAsync(room);
            }
        }
        public Task<int> DeleteRoomAsync(Room room)
        {
            return _database.DeleteAsync(room);
        }
        public Task<List<Room>> GetRoomsAsync()
        {
            return _database.Table<Room>().ToListAsync();
        }

        public Task<int> SaveListRoomAsync(ListRoom listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Room>> GetListRoomsAsync(int reservationlistid)
        {
            return _database.QueryAsync<Room>(
            "select P.ID, P.Description from Room P"
            + " inner join ListRoom LP"
            + " on P.ID = LP.RoomID where LP.ReservationListID = ?",
            reservationlistid);
        }

        public Task<List<Hotell>> GetHotelsAsync()
        {
            return _database.Table<Hotell>().ToListAsync();
        }
        public Task<int> SaveHotelAsync(Hotell hotel)
        {
            if (hotel.ID != 0)
            {
                return _database.UpdateAsync(hotel);
            }
            else
            {
                return _database.InsertAsync(hotel);
            }
        }
        public Task<int> DeleteHotelAsync(Hotell hotel)
        {
            return _database.DeleteAsync(hotel);
        }


    }
}

