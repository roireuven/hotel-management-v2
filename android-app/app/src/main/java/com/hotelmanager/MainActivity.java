package com.hotelmanager;

import android.os.Bundle;
import android.view.Window;
import android.webkit.JsResult;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.webkit.WebResourceRequest;
import android.webkit.DownloadListener;
import android.webkit.ValueCallback;
import android.net.Uri;
import android.content.Intent;
import android.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private static final int FILE_CHOOSER_REQUEST = 1001;
    private ValueCallback<Uri[]> mFileCallback;
    private WebView webView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        supportRequestWindowFeature(Window.FEATURE_NO_TITLE);
        if (getSupportActionBar() != null) {
            getSupportActionBar().hide();
        }

        webView = new WebView(this);
        setContentView(webView);

        WebSettings settings = webView.getSettings();
        settings.setJavaScriptEnabled(true);
        settings.setDomStorageEnabled(true);
        settings.setAllowFileAccess(true);
        settings.setUseWideViewPort(true);
        settings.setLoadWithOverviewMode(true);
        settings.setDatabaseEnabled(true);
        settings.setMediaPlaybackRequiresUserGesture(false);
        settings.setSupportZoom(true);
        settings.setBuiltInZoomControls(true);
        settings.setDisplayZoomControls(false);
        settings.setJavaScriptCanOpenWindowsAutomatically(true);

        webView.setWebViewClient(new WebViewClient() {
            @Override
            public boolean shouldOverrideUrlLoading(WebView view, WebResourceRequest request) {
                String url = request.getUrl().toString();
                if (url.startsWith("file:///android_asset/")) {
                    return false;
                }
                if (url.endsWith(".csv") || url.startsWith("blob:")) {
                    return false;
                }
                Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
                startActivity(intent);
                return true;
            }
        });

        webView.setWebChromeClient(new WebChromeClient() {
            @Override
            public boolean onJsAlert(WebView view, String url, String message, JsResult result) {
                new AlertDialog.Builder(MainActivity.this)
                    .setTitle("Hotel Manager")
                    .setMessage(message)
                    .setPositiveButton("OK", (dialog, which) -> result.confirm())
                    .setCancelable(false)
                    .show();
                return true;
            }

            @Override
            public boolean onJsConfirm(WebView view, String url, String message, JsResult result) {
                new AlertDialog.Builder(MainActivity.this)
                    .setTitle("Confirm")
                    .setMessage(message)
                    .setPositiveButton("Yes", (dialog, which) -> result.confirm())
                    .setNegativeButton("No", (dialog, which) -> result.cancel())
                    .setCancelable(false)
                    .show();
                return true;
            }

            @Override
            public boolean onShowFileChooser(WebView webView, ValueCallback<Uri[]> filePathCallback, FileChooserParams fileChooserParams) {
                if (mFileCallback != null) mFileCallback.onReceiveValue(null);
                mFileCallback = filePathCallback;
                Intent intent = fileChooserParams.createIntent();
                try {
                    startActivityForResult(intent, FILE_CHOOSER_REQUEST);
                } catch (Exception e) {
                    mFileCallback = null;
                    return false;
                }
                return true;
            }
        });

        webView.setDownloadListener((url, userAgent, contentDisposition, mimetype, contentLength) -> {
            if (url.startsWith("data:")) {
                try {
                    String[] parts = url.split(",", 2);
                    String header = parts[0];
                    String payload = parts.length > 1 ? parts[1] : "";
                    String ts = new java.text.SimpleDateFormat("yyyy-MM-dd_HHmmss", java.util.Locale.US).format(new java.util.Date());
                    java.io.File dir = android.os.Environment.getExternalStoragePublicDirectory(android.os.Environment.DIRECTORY_DOWNLOADS);
                    if (!dir.exists()) dir.mkdirs();

                    if (header.contains("base64")) {
                        String ext = header.contains("zip") ? ".zip" : header.contains("json") ? ".json" : ".bin";
                        String fileName = "hotel_export_" + ts + ext;
                        java.io.File file = new java.io.File(dir, fileName);
                        byte[] decoded = android.util.Base64.decode(payload, android.util.Base64.DEFAULT);
                        java.io.FileOutputStream fos = new java.io.FileOutputStream(file);
                        fos.write(decoded);
                        fos.close();
                        android.widget.Toast.makeText(MainActivity.this, "Saved to Downloads/" + fileName, android.widget.Toast.LENGTH_LONG).show();
                    } else {
                        String data = java.net.URLDecoder.decode(payload, "UTF-8");
                        String ext = header.contains("json") ? ".json" : ".csv";
                        String fileName = "hotel_export_" + ts + ext;
                        java.io.File file = new java.io.File(dir, fileName);
                        java.io.FileWriter writer = new java.io.FileWriter(file);
                        if (data.startsWith("\uFEFF")) data = data.substring(1);
                        writer.write(data);
                        writer.close();
                        android.widget.Toast.makeText(MainActivity.this, "Saved to Downloads/" + fileName, android.widget.Toast.LENGTH_LONG).show();
                    }
                } catch (Exception e) {
                    android.widget.Toast.makeText(MainActivity.this, "Error: " + e.getMessage(), android.widget.Toast.LENGTH_SHORT).show();
                }
            } else {
                Intent intent = new Intent(Intent.ACTION_VIEW, Uri.parse(url));
                startActivity(intent);
            }
        });

        DatabaseHelper dbHelper = new DatabaseHelper(this);
        JsBridge bridge = new JsBridge(dbHelper);
        webView.addJavascriptInterface(bridge, "HotelDB");

        webView.loadUrl("file:///android_asset/index.html");
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == FILE_CHOOSER_REQUEST) {
            if (mFileCallback != null) {
                Uri[] results = null;
                if (resultCode == RESULT_OK && data != null) {
                    String dataString = data.getDataString();
                    if (dataString != null) {
                        results = new Uri[]{Uri.parse(dataString)};
                    }
                }
                mFileCallback.onReceiveValue(results);
                mFileCallback = null;
            }
        }
    }

    @Override
    public void onBackPressed() {
        if (webView.canGoBack()) {
            webView.goBack();
        } else {
            super.onBackPressed();
        }
    }
}
