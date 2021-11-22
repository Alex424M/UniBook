using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
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
        public ShowMaterial()
        {
            InitializeComponent();
        }
        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application
            wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);

            Document doc = wordApplication.ActiveDocument;
            try
            {

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
            string doc = @"C:\Users\NyxSon\Desktop\UniBook\UniBook\Resource\ПР№9 Соколов Морозов.docx";
                    string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(doc), "\\",
                                   System.IO.Path.GetFileNameWithoutExtension(doc), ".xps");

                    documentViewer1.Document =
                        ConvertWordDocToXPSDoc(doc, newXPSDocumentName).GetFixedDocumentSequence();
              
        }
    }
}
