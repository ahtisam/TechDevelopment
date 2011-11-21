using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace TrendITech.Core.Utilities
{
    public class ListViewToCSV
    {

        public static void ListViewToCSV(ListView myList, string filePath, bool includeHidden)
        {
            ////make header srting
            //StringBuilder result = new StringBuilder();
            //WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);

            ////export data rows
            //foreach (var listItem in listView.Items)
            //    WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);

            //File.WriteAllText(filePath, result.ToString());

            StringBuilder sb = new StringBuilder();
            foreach (ColumnHeader ch in myList.Columns)
            {
                sb.Append(ch.Text + ",");
            }
            sb.AppendLine();
            foreach (ListViewItem lvi in myList.Items)
            {
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    if (lvs.Text.Trim() == string.Empty)
                        sb.Append(" ,");
                    else
                        sb.Append(lvs.Text + ",");
                }
                sb.AppendLine();
            }
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(sb.ToString());
                sw.Close();
            }

        }

        private void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
        {
            bool isFirstTime = true;
            for (int i = 0; i < itemsCount; i++)
            {
                if (!isColumnNeeded(i))
                    continue;

                if (!isFirstTime)
                    result.Append(",");
                isFirstTime = false;

                result.Append(String.Format("\"{0}\"", columnValue(i)));
            }
            result.AppendLine();
        }


    }
}
