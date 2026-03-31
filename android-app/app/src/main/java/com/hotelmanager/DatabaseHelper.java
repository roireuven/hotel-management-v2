package com.hotelmanager;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class DatabaseHelper extends SQLiteOpenHelper {

    private static final String DB_NAME = "hotel_manager.db";
    private static final int DB_VERSION = 2;

    public DatabaseHelper(Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS rooms (" +
            "id TEXT PRIMARY KEY, roomNumber TEXT, roomType TEXT, floorNumber INTEGER, " +
            "bedConfig TEXT, housekeepingStatus TEXT, occupancyStatus TEXT, " +
            "maxAdults INTEGER, maxChildren INTEGER, amenities TEXT, " +
            "maintenanceLogs TEXT, price REAL)");

        db.execSQL("CREATE TABLE IF NOT EXISTS guests (" +
            "id TEXT PRIMARY KEY, firstName TEXT, lastName TEXT, " +
            "passportId TEXT, nationality TEXT, dob TEXT, " +
            "email TEXT, phone TEXT, paymentMethod TEXT, " +
            "guestNotes TEXT, blacklist INTEGER DEFAULT 0, visits INTEGER DEFAULT 0)");

        db.execSQL("CREATE TABLE IF NOT EXISTS bookings (" +
            "id TEXT PRIMARY KEY, bookingId TEXT, guestId TEXT, guestName TEXT, " +
            "roomId TEXT, roomNumber TEXT, roomType TEXT, " +
            "checkinDate TEXT, checkinTime TEXT, checkoutDate TEXT, checkoutTime TEXT, " +
            "numAdults INTEGER, numChildren INTEGER, bookingSource TEXT, " +
            "cancellationPolicy TEXT, arrivalStatus TEXT, specialRequests TEXT, " +
            "services TEXT, notes TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS services (" +
            "id TEXT PRIMARY KEY, serviceCategory TEXT, name TEXT, " +
            "unitPrice REAL, quantity INTEGER, taxRate REAL, " +
            "serviceDateTime TEXT, staffId TEXT, icon TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS invoices (" +
            "id TEXT PRIMARY KEY, invoiceNumber TEXT, bookingId TEXT, guestName TEXT, " +
            "roomNumber TEXT, subtotal REAL, discountAmount REAL, " +
            "taxTotal REAL, grandTotal REAL, paymentStatus TEXT, " +
            "paymentTransactionId TEXT, currency TEXT, billingAddress TEXT, " +
            "services TEXT, date TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS accounts (" +
            "id TEXT PRIMARY KEY, name TEXT, email TEXT, role TEXT, status TEXT)");

        db.execSQL("CREATE TABLE IF NOT EXISTS audit_log (" +
            "id TEXT PRIMARY KEY, timestamp TEXT, userId TEXT, userName TEXT, " +
            "action TEXT, tableName TEXT, recordId TEXT, details TEXT)");

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
        db.execSQL("DROP TABLE IF EXISTS audit_log");
        db.execSQL("DROP TABLE IF EXISTS settings");
        onCreate(db);
    }
}
