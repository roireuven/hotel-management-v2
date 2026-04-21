package com.hotelmanager;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.webkit.JavascriptInterface;
import org.json.JSONArray;
import org.json.JSONObject;
import java.util.Iterator;

public class JsBridge {

    private final DatabaseHelper dbHelper;

    public JsBridge(DatabaseHelper dbHelper) {
        this.dbHelper = dbHelper;
    }

    @JavascriptInterface
    public String getAll(String table) {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT * FROM " + sanitize(table), null);
        JSONArray arr = cursorToJson(cursor);
        cursor.close();
        return arr.toString();
    }

    @JavascriptInterface
    public String getById(String table, String id) {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT * FROM " + sanitize(table) + " WHERE id=?", new String[]{id});
        JSONArray arr = cursorToJson(cursor);
        cursor.close();
        return arr.length() > 0 ? arr.optJSONObject(0).toString() : "null";
    }

    @JavascriptInterface
    public void upsert(String table, String jsonStr) {
        try {
            JSONObject obj = new JSONObject(jsonStr);
            SQLiteDatabase db = dbHelper.getWritableDatabase();
            ContentValues cv = jsonToContentValues(obj);
            long result = db.insertWithOnConflict(sanitize(table), null, cv, SQLiteDatabase.CONFLICT_REPLACE);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @JavascriptInterface
    public void upsertAll(String table, String jsonArrayStr) {
        try {
            JSONArray arr = new JSONArray(jsonArrayStr);
            SQLiteDatabase db = dbHelper.getWritableDatabase();
            db.beginTransaction();
            try {
                String tbl = sanitize(table);
                for (int i = 0; i < arr.length(); i++) {
                    JSONObject obj = arr.getJSONObject(i);
                    ContentValues cv = jsonToContentValues(obj);
                    db.insertWithOnConflict(tbl, null, cv, SQLiteDatabase.CONFLICT_REPLACE);
                }
                db.setTransactionSuccessful();
            } finally {
                db.endTransaction();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @JavascriptInterface
    public void deleteRow(String table, String id) {
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        db.delete(sanitize(table), "id=?", new String[]{id});
    }

    @JavascriptInterface
    public void deleteAll(String table) {
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        db.delete(sanitize(table), null, null);
    }

    @JavascriptInterface
    public int count(String table) {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT COUNT(*) FROM " + sanitize(table), null);
        int c = 0;
        if (cursor.moveToFirst()) c = cursor.getInt(0);
        cursor.close();
        return c;
    }

    @JavascriptInterface
    public void saveSetting(String key, String value) {
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        ContentValues cv = new ContentValues();
        cv.put("key", key);
        cv.put("value", value);
        db.insertWithOnConflict("settings", null, cv, SQLiteDatabase.CONFLICT_REPLACE);
    }

    @JavascriptInterface
    public String getSetting(String key) {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT value FROM settings WHERE key=?", new String[]{key});
        String val = null;
        if (cursor.moveToFirst()) val = cursor.getString(0);
        cursor.close();
        return val;
    }

    @JavascriptInterface
    public String getAllSettings() {
        SQLiteDatabase db = dbHelper.getReadableDatabase();
        Cursor cursor = db.rawQuery("SELECT * FROM settings", null);
        JSONObject obj = new JSONObject();
        try {
            while (cursor.moveToNext()) {
                obj.put(cursor.getString(cursor.getColumnIndexOrThrow("key")),
                        cursor.getString(cursor.getColumnIndexOrThrow("value")));
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        cursor.close();
        return obj.toString();
    }

    private JSONArray cursorToJson(Cursor cursor) {
        JSONArray arr = new JSONArray();
        String[] cols = cursor.getColumnNames();
        while (cursor.moveToNext()) {
            JSONObject obj = new JSONObject();
            try {
                for (String col : cols) {
                    int idx = cursor.getColumnIndex(col);
                    int type = cursor.getType(idx);
                    switch (type) {
                        case Cursor.FIELD_TYPE_INTEGER:
                            obj.put(col, cursor.getLong(idx));
                            break;
                        case Cursor.FIELD_TYPE_FLOAT:
                            obj.put(col, cursor.getDouble(idx));
                            break;
                        case Cursor.FIELD_TYPE_NULL:
                            obj.put(col, JSONObject.NULL);
                            break;
                        default:
                            obj.put(col, cursor.getString(idx));
                            break;
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
            arr.put(obj);
        }
        return arr;
    }

    private ContentValues jsonToContentValues(JSONObject obj) {
        ContentValues cv = new ContentValues();
        Iterator<String> keys = obj.keys();
        while (keys.hasNext()) {
            String key = keys.next();
            Object val = obj.opt(key);
            if (val == null || val == JSONObject.NULL) {
                cv.putNull(key);
            } else if (val instanceof Integer) {
                cv.put(key, (Integer) val);
            } else if (val instanceof Long) {
                cv.put(key, (Long) val);
            } else if (val instanceof Double) {
                cv.put(key, (Double) val);
            } else if (val instanceof Boolean) {
                cv.put(key, (Boolean) val ? 1 : 0);
            } else {
                cv.put(key, val.toString());
            }
        }
        return cv;
    }

    private String sanitize(String table) {
        return table.replaceAll("[^a-zA-Z0-9_]", "");
    }
}
