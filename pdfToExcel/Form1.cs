using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;
using System.Security.Permissions;

namespace pdfToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String pathExit = "";
        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pathExit = fbd.SelectedPath;

                }
            }
        }
        int count = 1;

        private void btn_seleccionarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "PDF | *.pdf"; // file types, that will be allowed to upload
                dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
                string fullPath;

                if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
                {
                    String path = dialog.FileName; // get name of file
                                                   // Create Bytescout.PDFExtractor.XLSExtractor instance
                                                   //< span data - scayt_word = "CSVExtractor" data - scaytid = "6" > CSVExtractor </ span > extractor = new < span data - scayt_word = "XLSExtractor" data - scaytid = "7" > XLSExtractor </ span > ();
                    Bytescout.PDFExtractor.XLSExtractor extractor = new Bytescout.PDFExtractor.XLSExtractor();
                    extractor.RegistrationName = "demo";
                    extractor.RegistrationKey = "demo";


                    // Load sample PDF document
                    extractor.LoadDocumentFromFile(path);
                    if (string.IsNullOrEmpty(pathExit))
                        fullPath = path.Split('.')[0] + ".xls";
                    else
                        fullPath = pathExit + "\\" + path.Split('\\').Last().Split('.')[0] + ".xls";

                    if (!File.Exists(fullPath))
                    {
                        extractor.SaveToXLSFile(fullPath);
                        DeleteSheet(fullPath);

                    }
                    else
                    {
                        int i = 1;
                        while (File.Exists(fullPath))
                        {
                            if (string.IsNullOrEmpty(pathExit))
                                fullPath = path.Split('.')[0] + "(" + (i++) + ")" + ".xls";
                            else
                                fullPath = pathExit + "\\" + path.Split('\\').Last().Split('.')[0] + "(" + (i++) + ")" + ".xls";
                        }

                        extractor.SaveToXLSFile(fullPath);
                        DeleteSheet(fullPath);

                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Se produjo un error reinicie el programa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Open the spreadsheet in default associated application
        }


        public void DeleteSheet(string path)
        {
            FileIOPermission fio = new FileIOPermission(FileIOPermissionAccess.Write, path);
            fio.Demand();
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook book =
            xlApp.Workbooks.Open(path);
            xlApp.DisplayAlerts = false;
            int c = 0;
            foreach (Excel.Worksheet xlworksheet in xlApp.Worksheets)
            {
                c++;
            }

          ((Excel.Worksheet)xlApp.ActiveWorkbook.Sheets[c]).Delete();
            xlApp.DisplayAlerts = true;
            book.Save();
            book.Close();
            xlApp.Quit();
            Marshal.ReleaseComObject(book);
            Marshal.ReleaseComObject(xlApp);
        }
        private bool GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            return true;
        }
    }
}
