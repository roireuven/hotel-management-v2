package com.hotelmanager.roommanagement.ui

import android.os.Bundle
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.google.android.material.dialog.MaterialAlertDialogBuilder
import com.google.android.material.snackbar.Snackbar
import com.hotelmanager.roommanagement.R
import com.hotelmanager.roommanagement.RoomManagementApp
import com.hotelmanager.roommanagement.data.HotelRoom
import com.hotelmanager.roommanagement.databinding.ActivityMainBinding
import com.hotelmanager.roommanagement.viewmodel.RoomViewModel
import com.hotelmanager.roommanagement.viewmodel.RoomViewModelFactory

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding

    private val roomViewModel: RoomViewModel by viewModels {
        RoomViewModelFactory((application as RoomManagementApp).repository)
    }

    private lateinit var adapter: RoomAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        setSupportActionBar(binding.toolbar)
        supportActionBar?.title = getString(R.string.app_name)

        setupRecyclerView()
        observeRooms()

        binding.fabAddRoom.setOnClickListener {
            showAddEditDialog(null)
        }
    }

    private fun setupRecyclerView() {
        adapter = RoomAdapter(
            onEdit = { room -> showAddEditDialog(room) },
            onDelete = { room -> confirmDelete(room) }
        )
        binding.recyclerView.layoutManager = LinearLayoutManager(this)
        binding.recyclerView.adapter = adapter
    }

    private fun observeRooms() {
        roomViewModel.allRooms.observe(this) { rooms ->
            adapter.submitList(rooms)
            binding.tvEmptyState.visibility = if (rooms.isEmpty()) {
                android.view.View.VISIBLE
            } else {
                android.view.View.GONE
            }
        }
    }

    private fun showAddEditDialog(room: HotelRoom?) {
        val dialog = AddEditRoomDialog.newInstance(room)
        dialog.onSave = { savedRoom ->
            if (room != null) {
                roomViewModel.update(savedRoom)
                Snackbar.make(binding.root, "Room updated", Snackbar.LENGTH_SHORT).show()
            } else {
                roomViewModel.insert(savedRoom)
                Snackbar.make(binding.root, "Room added", Snackbar.LENGTH_SHORT).show()
            }
        }
        dialog.show(supportFragmentManager, "add_edit_room")
    }

    private fun confirmDelete(room: HotelRoom) {
        MaterialAlertDialogBuilder(this)
            .setTitle("Delete Room")
            .setMessage("Are you sure you want to delete room ${room.roomNumber}?")
            .setPositiveButton("Delete") { _, _ ->
                roomViewModel.delete(room)
                Snackbar.make(binding.root, "Room deleted", Snackbar.LENGTH_SHORT).show()
            }
            .setNegativeButton("Cancel", null)
            .show()
    }
}
