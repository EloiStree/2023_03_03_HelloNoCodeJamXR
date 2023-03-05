using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Eloi
{

    public class E_CsvUtility
    {

    }



    public interface ICSVAbleFromString
    {

        public void GetExpectedColumn(out string[] columns);
        public void GetLines(out IEnumerable<string[]> perColumnValue);
    }


    [System.Serializable]
    public class CSV_ExpectedColumn
    {
        public string[] m_columnValue;
        public CSV_ExpectedColumn()
        {
            m_columnValue = new string[0];
        }
        public CSV_ExpectedColumn(params string[] columnValue)
        {
            m_columnValue = columnValue;
        }
        public CSV_ExpectedColumn(params object[] columnValue)
        {
            m_columnValue = new string[columnValue.Length];
            for (int i = 0; i < columnValue.Length; i++)
            {
                if (columnValue == null)
                    m_columnValue[i] = "";
                else m_columnValue[i] = columnValue[i].ToString();
            }
        }
        public string[] GetColumn() { return m_columnValue; }
    }
    [System.Serializable]
    public class CSV_Line
    {
        public string[] m_lineValuePerColumn;
        public CSV_Line(params string[] valuePerColumn)
        {
            m_lineValuePerColumn = valuePerColumn;
        }
        public CSV_Line(params object[] valuePerColumn)
        {
            m_lineValuePerColumn = new string[valuePerColumn.Length];
            for (int i = 0; i < valuePerColumn.Length; i++)
            {
                if (valuePerColumn == null)
                    m_lineValuePerColumn[i] = "";
                else m_lineValuePerColumn[i] = valuePerColumn[i].ToString();
            }
        }

        public string[] GetPerColumnValueOfLine() { return m_lineValuePerColumn; }

        public int GetNumberOfColumns()
        {
            return m_lineValuePerColumn.Length;
        }

        public bool TryToGetAs(in int columnIndex, out int parsedOrDefault, in int defaultValue)
        {

            if (columnIndex < 0 || columnIndex >= m_lineValuePerColumn.Length || !int.TryParse(m_lineValuePerColumn[columnIndex], out parsedOrDefault))
            {
                parsedOrDefault = defaultValue;
                return false;
            }
            return true;
        }
        public bool TryToGetAs(in int columnIndex, out float parsedOrDefault, in float defaultValue)
        {

            if (columnIndex < 0 || columnIndex >= m_lineValuePerColumn.Length || !float.TryParse(m_lineValuePerColumn[columnIndex], out parsedOrDefault))
            {
                parsedOrDefault = defaultValue;
                return false;
            }
            return true;
        }
        public bool TryToGetAs(in int columnIndex, out string valueOrDefault, in string defaultValue)
        {
            if (columnIndex < 0 || columnIndex >= m_lineValuePerColumn.Length)
            {
                valueOrDefault = defaultValue;
                return false;
            }
            else
            {
                valueOrDefault = m_lineValuePerColumn[columnIndex];
                return true;
            }
        }
    }


    public delegate void CSVAccessDataToStore(out CSV_ExpectedColumn expectedColumn, out List<CSV_Line> lineToStore);
    public delegate void CSVSetFromLines(in CSV_ExpectedColumn importedColumn, in List<CSV_Line> lineToStore);

    [System.Serializable]
    public class CSVBuilder
    {


        public CSV_ExpectedColumn m_expectedColumns = new CSV_ExpectedColumn();
        public List<CSV_Line> m_lines = new List<CSV_Line>();

        public CSVBuilder()
        {

        }
        public CSVBuilder(CSVAccessDataToStore fetchData)
        {
            SetWith(fetchData);
        }
        public CSVBuilder(in CSV_ExpectedColumn expectedColumns, params CSV_Line[] lineInformation)
        {
            m_expectedColumns = expectedColumns;
            m_lines.Clear();
            m_lines.AddRange(lineInformation);
        }
        public CSVBuilder(in string[] expectedColumns, params string[] lineInformation)
        {
            m_expectedColumns = new CSV_ExpectedColumn(expectedColumns.ToArray());
            m_lines.Clear();
            for (int i = 0; i < lineInformation.Length; i++)
            {
                m_lines.Add(new CSV_Line(lineInformation));
            }
        }

        public void Append(params CSV_Line[] lineValuePerColumn)
        {

            m_lines.AddRange(lineValuePerColumn);
        }

        public void SetWith(CSVAccessDataToStore accessData)
        {
            if (accessData == null)
                return;
            accessData(out m_expectedColumns, out m_lines);
        }


        public void ApplyTo(CSVSetFromLines targetToApplyTo)
        {
            if (targetToApplyTo == null)
                return;
            targetToApplyTo(in m_expectedColumns, in m_lines);
        }

        public void SetFromCSVText(in string csvText)
        {

            string[] lines = csvText.Split('\n');
            if (lines.Length < 1)
                return;
            m_expectedColumns = new CSV_ExpectedColumn(lines[0].Split(';'));
            m_lines.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] valuePerColumn = lines[i].Split(';');
                CSV_Line l = new CSV_Line(valuePerColumn);
                m_lines.Add(l);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Join(";", m_expectedColumns.GetColumn()));
            for (int i = 0; i < m_lines.Count; i++)
            {

                sb.AppendLine(string.Join(";", m_lines[i].GetPerColumnValueOfLine()));

            }
            return sb.ToString();
        }
    }

}