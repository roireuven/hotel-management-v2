const express = require('express');
const sql = require('mssql');
const crypto = require('crypto');
const path = require('path');

const app = express();
app.use(express.json());
app.use(express.static(path.join(__dirname, 'public')));

const dbConfig = {
    server: process.env.DB_SERVER || 'localhost',
    database: process.env.DB_NAME || 'HotelManagement',
    user: process.env.DB_USER || 'sa',
    password: process.env.DB_PASSWORD || 'HotelMgmt123!',
    port: parseInt(process.env.DB_PORT || '1433'),
    options: {
        encrypt: process.env.DB_ENCRYPT === 'true',
        trustServerCertificate: true
    }
};

let pool;
async function getPool() {
    if (!pool) pool = await sql.connect(dbConfig);
    return pool;
}

function md5(text) {
    return crypto.createHash('md5').update(text, 'utf8').digest('hex');
}

// Auth
app.post('/api/login', async (req, res) => {
    try {
        const { username, password } = req.body;
        if (!username || !password) return res.status(400).json({ error: 'Missing credentials' });
        const p = await getPool();
        const result = await p.request()
            .input('userName', sql.NVarChar, username)
            .input('passWord', sql.NVarChar, md5(password))
            .query("EXEC USP_Login @userName, @passWord");
        if (result.recordset.length > 0) {
            res.json({ success: true, user: username });
        } else {
            res.status(401).json({ error: 'Invalid credentials' });
        }
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Dashboard KPIs
app.get('/api/dashboard', async (req, res) => {
    try {
        const p = await getPool();
        const today = new Date().toISOString().split('T')[0];
        const month = new Date().getMonth() + 1;
        const year = new Date().getFullYear();

        const [arrivals, departures, totalRooms, occupiedRooms, revenue] = await Promise.all([
            p.request().input('d', sql.Date, today).query("SELECT COUNT(*) as c FROM BookRoom WHERE DateCheckIn = @d"),
            p.request().input('d', sql.Date, today).query("SELECT COUNT(*) as c FROM BookRoom WHERE DateCheckOut = @d"),
            p.request().query("SELECT COUNT(*) as c FROM Room"),
            p.request().query("SELECT COUNT(*) as c FROM Room r JOIN StatusRoom s ON r.IDStatusRoom = s.ID WHERE s.Name = N'Có người'"),
            p.request().input('m', sql.Int, month).input('y', sql.Int, year)
                .query("SELECT ISNULL(SUM(TotalPrice), 0) as total FROM Bill WHERE MONTH(DateOfCreate) = @m AND YEAR(DateOfCreate) = @y")
        ]);

        const total = totalRooms.recordset[0].c;
        const occupied = occupiedRooms.recordset[0].c;
        const occupancy = total > 0 ? ((occupied / total) * 100).toFixed(1) : 0;
        const revpar = total > 0 ? Math.round(revenue.recordset[0].total / total) : 0;

        let pricing = 'NORMAL';
        let pricingMult = 1.0;
        if (parseFloat(occupancy) > 80) { pricing = 'SURGE'; pricingMult = 1.2; }
        else if (parseFloat(occupancy) < 30) { pricing = 'DISCOUNT'; pricingMult = 0.9; }

        res.json({
            arrivals: arrivals.recordset[0].c,
            departures: departures.recordset[0].c,
            totalRooms: total,
            occupied,
            available: total - occupied,
            occupancy: parseFloat(occupancy),
            revpar,
            pricing,
            pricingMult
        });
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Rooms
app.get('/api/rooms', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT r.ID, r.Name as RoomName, rt.Name as RoomType, rt.Price, rt.LimitPerson as MaxOccupancy, s.Name as Status
            FROM Room r JOIN RoomType rt ON r.IDRoomType = rt.ID JOIN StatusRoom s ON r.IDStatusRoom = s.ID
            ORDER BY r.Name`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Bookings
app.get('/api/bookings', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT br.ID, c.Name as GuestName, c.PhoneNumber, rt.Name as RoomType,
                   br.DateCheckIn, br.DateCheckOut, br.DateBookRoom
            FROM BookRoom br
            JOIN Customer c ON br.IDCustomer = c.ID
            JOIN RoomType rt ON br.IDRoomType = rt.ID
            ORDER BY br.DateCheckIn DESC`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Guests
app.get('/api/guests', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT c.ID, c.Name, c.IDCard, ct.Name as CustomerType, c.Sex, c.DateOfBirth,
                   c.PhoneNumber, c.Address, c.Nationality
            FROM Customer c JOIN CustomerType ct ON c.IDCustomerType = ct.ID
            ORDER BY c.Name`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Staff
app.get('/api/staff', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT s.UserName, s.DisplayName, st.Name as StaffType, s.IDCard, s.Sex,
                   s.DateOfBirth, s.PhoneNumber, s.Address, s.StartDay
            FROM Staff s JOIN StaffType st ON s.IDStaffType = st.ID
            ORDER BY s.DisplayName`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Bills
app.get('/api/bills', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT b.ID, b.StaffSetUp, b.DateOfCreate, b.RoomPrice, b.ServicePrice,
                   b.TotalPrice, b.Discount, b.Surcharge, sb.Name as Status
            FROM Bill b JOIN StatusBill sb ON b.IDStatusBill = sb.ID
            ORDER BY b.DateOfCreate DESC`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// Services
app.get('/api/services', async (req, res) => {
    try {
        const p = await getPool();
        const result = await p.request().query(`
            SELECT s.ID, s.Name, st.Name as ServiceType, s.Price
            FROM Service s JOIN ServiceType st ON s.IDServiceType = st.ID
            ORDER BY st.Name, s.Name`);
        res.json(result.recordset);
    } catch (e) { res.status(500).json({ error: e.message }); }
});

// AI Parse
app.post('/api/parse-booking', (req, res) => {
    const { text } = req.body;
    if (!text) return res.status(400).json({ error: 'No text' });

    const nameMatch = text.match(/(?:guest\s*name|name|guest)\s*[:\-]\s*([A-Za-z\s]+?)(?:,|\n|$)/i);
    const checkInMatch = text.match(/(?:check[\s-]*in|arrival|from)\s*[:\-]\s*(\d{4}[\-\/]\d{1,2}[\-\/]\d{1,2}|\w+\s+\d{1,2},?\s*\d{4})/i);
    const checkOutMatch = text.match(/(?:check[\s-]*out|departure|to)\s*[:\-]\s*(\d{4}[\-\/]\d{1,2}[\-\/]\d{1,2}|\w+\s+\d{1,2},?\s*\d{4})/i);
    const priceMatch = text.match(/(?:price|rate|total|amount)\s*[:\-]\s*\$?\s*([\d,]+\.?\d*)/i);

    res.json({
        name: nameMatch ? nameMatch[1].trim() : null,
        checkIn: checkInMatch ? checkInMatch[1].trim() : null,
        checkOut: checkOutMatch ? checkOutMatch[1].trim() : null,
        price: priceMatch ? priceMatch[1].trim() : null
    });
});

// Sentiment
app.post('/api/sentiment', (req, res) => {
    const { text } = req.body;
    if (!text) return res.status(400).json({ error: 'No text' });
    const lower = text.toLowerCase();
    const highValue = ['vip', 'anniversary', 'honeymoon', 'birthday', 'celebration', 'special occasion', 'loyalty', 'returning', 'premium'];
    const highMaint = ['complaint', 'unhappy', 'dissatisfied', 'refund', 'problem', 'issue', 'allergic', 'disability', 'wheelchair', 'medical'];

    if (highValue.some(k => lower.includes(k))) return res.json({ sentiment: 'High-Value', badge: 'success' });
    if (highMaint.some(k => lower.includes(k))) return res.json({ sentiment: 'High-Maintenance', badge: 'danger' });
    res.json({ sentiment: 'Normal', badge: 'secondary' });
});

const PORT = process.env.PORT || 3000;
app.listen(PORT, '0.0.0.0', () => console.log('Hotel PMS Web running on port ' + PORT));
