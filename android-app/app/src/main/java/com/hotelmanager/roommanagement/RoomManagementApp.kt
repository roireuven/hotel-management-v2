package com.hotelmanager.roommanagement

import android.app.Application
import com.hotelmanager.roommanagement.data.AppDatabase
import com.hotelmanager.roommanagement.data.RoomRepository

class RoomManagementApp : Application() {

    val database by lazy { AppDatabase.getDatabase(this) }
    val repository by lazy { RoomRepository(database.hotelRoomDao()) }
}
