package com.hotelmanager.roommanagement.ui

import android.app.Dialog
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import androidx.fragment.app.DialogFragment
import com.google.android.material.dialog.MaterialAlertDialogBuilder
import com.hotelmanager.roommanagement.R
import com.hotelmanager.roommanagement.data.HotelRoom
import com.hotelmanager.roommanagement.databinding.DialogAddEditRoomBinding

class AddEditRoomDialog : DialogFragment() {

    private var _binding: DialogAddEditRoomBinding? = null
    private val binding get() = _binding!!

    private var existingRoom: HotelRoom? = null
    var onSave: ((HotelRoom) -> Unit)? = null

    companion object {
        private const val ARG_ROOM_ID = "room_id"
        private const val ARG_ROOM_NUMBER = "room_number"
        private const val ARG_FLOOR = "floor"
        private const val ARG_ROOM_TYPE = "room_type"
        private const val ARG_PRICE = "price"
        private const val ARG_MAX_GUESTS = "max_guests"

        fun newInstance(room: HotelRoom? = null): AddEditRoomDialog {
            val dialog = AddEditRoomDialog()
            room?.let {
                dialog.arguments = Bundle().apply {
                    putLong(ARG_ROOM_ID, it.id)
                    putString(ARG_ROOM_NUMBER, it.roomNumber)
                    putInt(ARG_FLOOR, it.floor)
                    putString(ARG_ROOM_TYPE, it.roomType)
                    putDouble(ARG_PRICE, it.pricePerNight)
                    putInt(ARG_MAX_GUESTS, it.maxGuests)
                }
            }
            return dialog
        }

        val ROOM_TYPES = listOf(
            "Standard",
            "Deluxe",
            "Suite",
            "Executive",
            "Presidential",
            "Family",
            "Single",
            "Double",
            "Twin",
            "Penthouse"
        )
    }

    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {
        _binding = DialogAddEditRoomBinding.inflate(LayoutInflater.from(requireContext()))

        arguments?.let { args ->
            existingRoom = HotelRoom(
                id = args.getLong(ARG_ROOM_ID),
                roomNumber = args.getString(ARG_ROOM_NUMBER, ""),
                floor = args.getInt(ARG_FLOOR),
                roomType = args.getString(ARG_ROOM_TYPE, "Standard"),
                pricePerNight = args.getDouble(ARG_PRICE),
                maxGuests = args.getInt(ARG_MAX_GUESTS)
            )
        }

        setupRoomTypeSpinner()
        populateFields()

        val title = if (existingRoom != null) "Edit Room" else "Add New Room"
        val buttonText = if (existingRoom != null) "Save Changes" else "Add Room"

        return MaterialAlertDialogBuilder(requireContext(), R.style.ThemeOverlay_App_MaterialAlertDialog)
            .setTitle(title)
            .setView(binding.root)
            .setPositiveButton(buttonText) { _, _ -> saveRoom() }
            .setNegativeButton("Cancel", null)
            .create()
    }

    private fun setupRoomTypeSpinner() {
        val adapter = ArrayAdapter(
            requireContext(),
            android.R.layout.simple_spinner_item,
            ROOM_TYPES
        )
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        binding.spinnerRoomType.adapter = adapter
    }

    private fun populateFields() {
        existingRoom?.let { room ->
            binding.etRoomNumber.setText(room.roomNumber)
            binding.etFloor.setText(room.floor.toString())
            binding.spinnerRoomType.setSelection(
                ROOM_TYPES.indexOf(room.roomType).coerceAtLeast(0)
            )
            binding.etPrice.setText(room.pricePerNight.toString())
            binding.etMaxGuests.setText(room.maxGuests.toString())
        }
    }

    private fun saveRoom() {
        val roomNumber = binding.etRoomNumber.text.toString().trim()
        val floorStr = binding.etFloor.text.toString().trim()
        val roomType = binding.spinnerRoomType.selectedItem.toString()
        val priceStr = binding.etPrice.text.toString().trim()
        val maxGuestsStr = binding.etMaxGuests.text.toString().trim()

        if (roomNumber.isEmpty() || floorStr.isEmpty() || priceStr.isEmpty() || maxGuestsStr.isEmpty()) {
            return
        }

        val floor = floorStr.toIntOrNull() ?: return
        val price = priceStr.toDoubleOrNull() ?: return
        val maxGuests = maxGuestsStr.toIntOrNull() ?: return

        val room = HotelRoom(
            id = existingRoom?.id ?: 0,
            roomNumber = roomNumber,
            floor = floor,
            roomType = roomType,
            pricePerNight = price,
            maxGuests = maxGuests
        )

        onSave?.invoke(room)
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}
