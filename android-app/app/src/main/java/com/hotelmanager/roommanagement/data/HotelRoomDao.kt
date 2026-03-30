package com.hotelmanager.roommanagement.data

import androidx.lifecycle.LiveData
import androidx.room.*

@Dao
interface HotelRoomDao {

    @Query("SELECT * FROM rooms ORDER BY roomNumber ASC")
    fun getAllRooms(): LiveData<List<HotelRoom>>

    @Insert(onConflict = OnConflictStrategy.REPLACE)
    suspend fun insert(room: HotelRoom): Long

    @Update
    suspend fun update(room: HotelRoom)

    @Delete
    suspend fun delete(room: HotelRoom)

    @Query("DELETE FROM rooms WHERE id = :roomId")
    suspend fun deleteById(roomId: Long)

    @Query("SELECT * FROM rooms WHERE id = :roomId")
    suspend fun getRoomById(roomId: Long): HotelRoom?

    @Query("SELECT * FROM rooms WHERE roomNumber = :number LIMIT 1")
    suspend fun getRoomByNumber(number: String): HotelRoom?
}
