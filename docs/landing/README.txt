Hotel Manager — Landing page for GitHub Pages
==============================================

Contents
--------
  index.html      Static landing page (Tailwind + Font Awesome via CDN)

APK download
------------
  The landing page downloads the release build from GitHub:

    https://github.com/roireuven/hotel-management-v2/releases/download/v8.4/HotelManager-v8.4-release.apk

  Publish a Release tagged v8.4 on hotel-management-v2 and attach
  HotelManager-v8.4-release.apk (signed build from your current sources).

GitHub Pages
------------
  1. Copy this folder into your repo as: docs/landing/
     (so you have docs/landing/index.html and docs/landing/app-release.apk)

  2. Repository Settings → Pages → Source: Deploy from branch "main", folder "/docs"

  3. Your landing page will be at:
     https://YOUR_USERNAME.github.io/YOUR_REPO/landing/

Notes
-----
  If your site root must show this page only, rename paths accordingly.
  The main Hotel Manager web app can stay at docs/index.html as a different URL.
