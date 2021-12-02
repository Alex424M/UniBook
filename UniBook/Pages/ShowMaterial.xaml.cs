using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;

namespace UniBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowMaterial.xaml
    /// </summary>
    public partial class ShowMaterial : System.Windows.Controls.Page
    {
        public ShowMaterial(int IDMaterial)
        {
            InitializeComponent();
            IDMaterial1 = IDMaterial;
        }
        int IDMaterial1;
        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application
            wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);

            Document doc = wordApplication.ActiveDocument;
            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);

                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            
              
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string name;
            string sqlExpression = $"SELECT Material FROM Material WHERE ID='{IDMaterial1}'";
            using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-PINVO2L\SQLEXPRESS;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlExpression;
                command.Connection = connection;
                name = command.ExecuteScalar().ToString();
            }
            string doc = name;
            string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(doc), "\\",
                           System.IO.Path.GetFileNameWithoutExtension(doc), ".xps");

            documentViewer1.Document =
                ConvertWordDocToXPSDoc(doc, newXPSDocumentName).GetFixedDocumentSequence();
        }
    }
}
