package com.hotelmanager.roommanagement.ui

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.hotelmanager.roommanagement.data.HotelRoom
import com.hotelmanager.roommanagement.databinding.ItemRoomRowBinding
import java.text.NumberFormat
import java.util.Locale

class RoomAdapter(
    private val onEdit: (HotelRoom) -> Unit,
    private val onDelete: (HotelRoom) -> Unit
) : ListAdapter<HotelRoom, RoomAdapter.RoomViewHolder>(RoomDiffCallback()) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RoomViewHolder {
        val binding = ItemRoomRowBinding.inflate(
            LayoutInflater.from(parent.context), parent, false
        )
        return RoomViewHolder(binding)
    }

    override fun onBindViewHolder(holder: RoomViewHolder, position: Int) {
        holder.bind(getItem(position))
    }

    inner class RoomViewHolder(
        private val binding: ItemRoomRowBinding
    ) : RecyclerView.ViewHolder(binding.root) {

        fun bind(room: HotelRoom) {
            val currencyFormat = NumberFormat.getCurrencyInstance(Locale.US)
            binding.tvRoomNumber.text = room.roomNumber
            binding.tvFloor.text = room.floor.toString()
            binding.tvRoomType.text = room.roomType
            binding.tvPrice.text = currencyFormat.format(room.pricePerNight)
            binding.tvMaxGuests.text = room.maxGuests.toString()

            binding.btnEdit.setOnClickListener { onEdit(room) }
            binding.btnDelete.setOnClickListener { onDelete(room) }
        }
    }
}

class RoomDiffCallback : DiffUtil.ItemCallback<HotelRoom>() {
    override fun areItemsTheSame(oldItem: HotelRoom, newItem: HotelRoom): Boolean {
        return oldItem.id == newItem.id
    }

    override fun areContentsTheSame(oldItem: HotelRoom, newItem: HotelRoom): Boolean {
        return oldItem == newItem
    }
}
