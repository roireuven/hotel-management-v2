const fs = require('fs');
const path = require('path');
const p = path.join(__dirname, '..', 'index.html');
const h = fs.readFileSync(p, 'utf8');
const codes = ['en', 'fr', 'es', 'he', 'th', 'lo'];
codes.forEach((c) => {
  const re = new RegExp(
    'id="i18n-' + c + '-embedded"[^>]*>\\s*([\\s\\S]*?)\\s*<\\/script>',
    'i'
  );
  const m = re.exec(h);
  if (!m) process.exit(1);
  JSON.parse(m[1].trim());
  console.log('ok', c);
});
console.log('all embedded valid');
