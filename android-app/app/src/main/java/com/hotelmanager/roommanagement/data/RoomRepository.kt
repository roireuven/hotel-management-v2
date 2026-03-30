package com.hotelmanager.roommanagement.data

import androidx.lifecycle.LiveData

class RoomRepository(private val roomDao: HotelRoomDao) {

    val allRooms: LiveData<List<HotelRoom>> = roomDao.getAllRooms()

    suspend fun insert(room: HotelRoom): Long = roomDao.insert(room)

    suspend fun update(room: HotelRoom) = roomDao.update(room)

    suspend fun delete(room: HotelRoom) = roomDao.delete(room)

    suspend fun deleteById(roomId: Long) = roomDao.deleteById(roomId)

    suspend fun getRoomById(roomId: Long): HotelRoom? = roomDao.getRoomById(roomId)

    suspend fun getRoomByNumber(number: String): HotelRoom? = roomDao.getRoomByNumber(number)
}
