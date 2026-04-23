/**
 * Regenerates <script type="application/json" id="i18n-XX-embedded"> in docs/index.html
 * from docs/assets/locales/*.json (for offline file:// and fetch failures).
 * Usage: node docs/scripts/sync-embedded-locales.cjs
 */
const fs = require('fs');
const path = require('path');

const docsDir = path.join(__dirname, '..');
const indexPath = path.join(docsDir, 'index.html');
const localesDir = path.join(docsDir, 'assets', 'locales');
const CODES = ['en', 'fr', 'es', 'he', 'th', 'lo'];

function replaceEmbeddedBlock(html, code, jsonPretty) {
  const id = `i18n-${code}-embedded`;
  const startMark = new RegExp(
    `<script\\s+type="application/json"\\s+id="${id}"\\s*>`,
    'i'
  );
  const m = html.match(startMark);
  if (!m) {
    throw new Error(`Missing script block: ${id}`);
  }
  const start = m.index;
  const afterOpen = start + m[0].length;
  const end = html.indexOf('</script>', afterOpen);
  if (end < 0) throw new Error(`No </script> for ${id}`);
  return html.slice(0, afterOpen) + '\n' + jsonPretty + '\n  ' + html.slice(end);
}

let html = fs.readFileSync(indexPath, 'utf8');
CODES.forEach((code) => {
  const fp = path.join(localesDir, `${code}.json`);
  if (!fs.existsSync(fp)) {
    console.warn('skip missing', fp);
    return;
  }
  const json = JSON.parse(fs.readFileSync(fp, 'utf8'));
  const minified = JSON.stringify(json, null, 2);
  html = replaceEmbeddedBlock(html, code, minified);
  console.log('updated', 'i18n-' + code + '-embedded');
});
fs.writeFileSync(indexPath, html);
console.log('wrote', indexPath);
