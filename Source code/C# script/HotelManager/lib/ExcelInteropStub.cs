using System;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel
{
    public enum XlFileFormat
    {
        xlWorkbookNormal = -4143,
        xlOpenXMLWorkbook = 51
    }

    public enum XlSaveAsAccessMode
    {
        xlExclusive = 3,
        xlNoChange = 1,
        xlShared = 2
    }

    public enum XlSaveConflictResolution
    {
        xlLocalSessionChanges = 2,
        xlOtherSessionChanges = 3,
        xlUserResolution = 1
    }

    public enum XlFixedFormatType
    {
        xlTypePDF = 0,
        xlTypeXPS = 1
    }

    public enum XlFixedFormatQuality
    {
        xlQualityMinimum = 0,
        xlQualityStandard = 1
    }

    public enum XlHAlign
    {
        xlHAlignCenter = -4108,
        xlHAlignLeft = 1
    }

    public enum XlRowCol
    {
        xlColumns = 2,
        xlRows = 1
    }

    public class Application
    {
        public Workbooks Workbooks { get { return new Workbooks(); } }
        public bool DisplayAlerts { get; set; }
        public bool Visible { get; set; }
        public void Quit() { }
    }

    public class Workbooks
    {
        public Workbook Add(object template = null) { return new Workbook(); }
    }

    public class Workbook
    {
        public Sheets Worksheets { get { return new Sheets(); } }
        public void SaveAs(object filename, object fileFormat = null, object password = null,
            object writeResPassword = null, object readOnlyRecommended = null,
            object createBackup = null, XlSaveAsAccessMode accessMode = XlSaveAsAccessMode.xlNoChange,
            object conflictResolution = null, object addToMru = null,
            object textCodepage = null, object textVisualLayout = null,
            object local = null) { }
        public void Close(object saveChanges = null, object filename = null, object routeWorkbook = null) { }
        public void ExportAsFixedFormat(XlFixedFormatType type, object filename,
            object quality = null, object includeDocProperties = null,
            object ignorePrintAreas = null, object from = null,
            object to = null, object openAfterPublish = null,
            object fixedFormatExtClassPtr = null) { }
        public bool Saved { get; set; }
    }

    public class Sheets
    {
        public object this[object index] { get { return new Worksheet(); } }
    }

    public class Worksheet
    {
        public dynamic Cells { get { return new Range(); } }
        public Range Columns { get { return new Range(); } }
        public Range Rows { get { return new Range(); } }
        public Range Range(object cell1, object cell2 = null) { return new Range(); }
    }

    public class Range
    {
        public Range this[object rowOrSingle] { set { } get { return new Range(); } }
        public Range this[object row, object column] { set { } get { return new Range(); } }
        public void Insert(object shift = null, object copyOrigin = null) { }
        public void AutoFit() { }
        public XlHAlign HorizontalAlignment { get; set; }
        public Font Font { get { return new Font(); } }

        public static implicit operator Range(string s) { return new Range(); }
    }

    public class Font
    {
        public bool Bold { get; set; }
        public double Size { get; set; }
    }
}
