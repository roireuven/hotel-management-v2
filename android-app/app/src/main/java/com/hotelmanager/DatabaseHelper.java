package com.hotelmanager;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {

    private static final String DB_NAME = "hotel_manager.db";
    private static final int DB_VERSION = 1;

    public DatabaseHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS rooms (" +
            "id TEXT PRIMARY KEY, number INTEGER, floor INTEGER, type TEXT, " +
            "price REAL, maxGuests INTEGER, status TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS guests (" +
            "id TEXT PRIMARY KEY, firstName TEXT, lastName TEXT, email TEXT, " +
            "phone TEXT, idDoc TEXT, visits INTEGER DEFAULT 0)");

        db.execSQL("CREATE TABLE IF NOT EXISTS bookings (" +
            "id TEXT PRIMARY KEY, guestId TEXT, guestName TEXT, roomId TEXT, " +
            "roomNumber INTEGER, roomType TEXT, checkin TEXT, checkout TEXT, " +
            "status TEXT, services TEXT, notes TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS services (" +
            "id TEXT PRIMARY KEY, name TEXT, category TEXT, price REAL, icon TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS invoices (" +
            "id TEXT PRIMARY KEY, bookingId TEXT, guestName TEXT, roomNumber TEXT, " +
            "nights INTEGER, roomCharge REAL, serviceCharge REAL, total REAL, " +
            "services TEXT, status TEXT, date TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS accounts (" +
            "id TEXT PRIMARY KEY, name TEXT, email TEXT, role TEXT, status TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS settings (" +
            "key TEXT PRIMARY KEY, value TEXT)");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS rooms");
        db.execSQL("DROP TABLE IF EXISTS guests");
        db.execSQL("DROP TABLE IF EXISTS bookings");
        db.execSQL("DROP TABLE IF EXISTS services");
        db.execSQL("DROP TABLE IF EXISTS invoices");
        db.execSQL("DROP TABLE IF EXISTS accounts");
        db.execSQL("DROP TABLE IF EXISTS settings");
        onCreate(db);
    }
}
