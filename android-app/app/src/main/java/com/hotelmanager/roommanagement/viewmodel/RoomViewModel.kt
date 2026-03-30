package com.hotelmanager.roommanagement.viewmodel

import androidx.lifecycle.*
import com.hotelmanager.roommanagement.data.HotelRoom
import com.hotelmanager.roommanagement.data.RoomRepository
import kotlinx.coroutines.launch

class RoomViewModel(private val repository: RoomRepository) : ViewModel() {

    val allRooms: LiveData<List<HotelRoom>> = repository.allRooms

    fun insert(room: HotelRoom) = viewModelScope.launch {
        repository.insert(room)
    }

    fun update(room: HotelRoom) = viewModelScope.launch {
        repository.update(room)
    }

    fun delete(room: HotelRoom) = viewModelScope.launch {
        repository.delete(room)
    }

    fun deleteById(roomId: Long) = viewModelScope.launch {
        repository.deleteById(roomId)
    }
}

class RoomViewModelFactory(private val repository: RoomRepository) : ViewModelProvider.Factory {
    override fun <T : ViewModel> create(modelClass: Class<T>): T {
        if (modelClass.isAssignableFrom(RoomViewModel::class.java)) {
            @Suppress("UNCHECKED_CAST")
            return RoomViewModel(repository) as T
        }
        throw IllegalArgumentException("Unknown ViewModel class")
    }
}
