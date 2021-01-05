using CsvHelper;
using Jizhujian.Shirui.考勤;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jizhujian.Shirui
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void Step1Button_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() != DialogResult.OK)
      {
        return;
      }
      IEnumerable<考勤原始记录> records;
      using (StreamReader reader2 = new StreamReader(openFileDialog1.FileName))
      {
        using CsvReader csvReader = new CsvReader(reader2, CultureInfo.InvariantCulture);
        csvReader.Configuration.Delimiter = "\t";
        records = csvReader.GetRecords<考勤原始记录>().ToList();
      }
      var results = (from record in records
                     where !string.IsNullOrWhiteSpace(record.工号)
                     let 工号 = record.工号.TrimStart('0')
                     group record.时间.TimeOfDay by new
                     {
                       工号,
                       日期 = record.时间.Date
                     } into 打卡记录
                     orderby 打卡记录.Key.工号, 打卡记录.Key.日期
                     select new
                     {
                       打卡记录.Key.工号,
                       打卡记录.Key.日期,
                       打卡次数 = 打卡记录.Count(),
                       上班时间 = 打卡记录.Min(),
                       下班时间 = 打卡记录.Max(),
                       打卡记录 = string.Join(",", 打卡记录.Select(time => time.ToString("hh\\:mm")))
                     }).ToList();
      IEnumerable<职工花名册> employees;
      using (StreamReader reader = new StreamReader("职工花名册.csv"))
      {
        using CsvReader csvReader2 = new CsvReader(reader, CultureInfo.InvariantCulture);
        employees = (from employee in csvReader2.GetRecords<职工花名册>().ToList()
                     orderby employee.工号
                     select employee).ToList();
      }
      var formatResults = (from record in results
                           join employee in employees on record.工号 equals employee.工号 into 职员数据
                           from subemployee in 职员数据.DefaultIfEmpty()
                           orderby record.工号, record.日期
                           select new
                           {
                             record.工号,
                             姓名 = (subemployee?.姓名 ?? string.Empty),
                             部门 = (subemployee?.部门 ?? string.Empty),
                             班组 = (subemployee?.班组 ?? string.Empty),
                             岗位 = (subemployee?.岗位 ?? string.Empty),
                             日期 = record.日期.ToShortDateString(),
                             record.打卡次数,
                             上班时间 = record.上班时间.ToString("hh\\:mm"),
                             下班时间 = record.下班时间.ToString("hh\\:mm"),
                             计算工时 = Math.Round((record.下班时间 - record.上班时间).TotalHours, 1),
                             扣除工时 = (subemployee?.扣除工时 ?? 0.0),
                             工时 = Math.Round((record.下班时间 - record.上班时间).TotalHours, 1) - (subemployee?.扣除工时 ?? 0.0),
                             record.打卡记录
                           }).ToList();
      using (StreamWriter writer = new StreamWriter("考勤原始记录分析结果.csv", append: false, Encoding.UTF8))
      {
        using CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(formatResults);
      }
      MessageBox.Show($"考勤原始记录分析结果：写入{formatResults.Count()}条");

    }

    private void Step2Button_Click(object sender, EventArgs e)
    {
      IEnumerable<考勤处理结果> records;
      using (StreamReader reader2 = new StreamReader("考勤原始记录分析结果.csv"))
      {
        using CsvReader csvReader = new CsvReader(reader2, CultureInfo.InvariantCulture);
        records = csvReader.GetRecords<考勤处理结果>().ToList();
      }
      using (StreamReader reader = new StreamReader("职工花名册.csv"))
      {
        using CsvReader csvReader2 = new CsvReader(reader, CultureInfo.InvariantCulture);
        IEnumerable<职工花名册> employees = csvReader2.GetRecords<职工花名册>().ToList();
      }
      var results = (from record in records
                     let 工号 = "_" + record.工号.PadLeft(5, '0')
                     orderby 工号, record.日期
                     select new
                     {
                       工号 = 工号,
                       姓名 = record.姓名,
                       部门 = record.部门,
                       班组 = record.班组,
                       岗位 = record.岗位,
                       日期 = record.日期.ToShortDateString(),
                       上班时间 = record.上班时间.ToString("hh\\:mm"),
                       下班时间 = record.下班时间.ToString("hh\\:mm"),
                       计算工时 = Math.Round((record.下班时间 - record.上班时间).TotalHours, 1),
                       扣除工时 = record.扣除工时,
                       工时 = Math.Round((record.下班时间 - record.上班时间).TotalHours, 1) - record.扣除工时
                     }).ToList();
      using (StreamWriter writer = new StreamWriter("考勤数据.csv", append: false, Encoding.UTF8))
      {
        using CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(results);
      }
      MessageBox.Show("已生成考勤数据。");
    }
  }
}
