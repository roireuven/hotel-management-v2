package com.hotelmanager.roommanagement.data

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "rooms")
data class HotelRoom(
    @PrimaryKey(autoGenerate = true)
    val id: Long = 0,
    val roomNumber: String,
    val floor: Int,
    val roomType: String,
    val pricePerNight: Double,
    val maxGuests: Int
)
