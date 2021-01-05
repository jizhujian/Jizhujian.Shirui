using System;

namespace Jizhujian.Shirui.考勤
{
  public class 考勤处理结果
  {
    public string 工号
    {
      get;
      set;
    }

    public string 姓名
    {
      get;
      set;
    }

    public string 部门
    {
      get;
      set;
    }

    public string 班组
    {
      get;
      set;
    }

    public string 岗位
    {
      get;
      set;
    }

    public DateTime 日期
    {
      get;
      set;
    }

    public TimeSpan 上班时间
    {
      get;
      set;
    }

    public TimeSpan 下班时间
    {
      get;
      set;
    }

    public double 扣除工时
    {
      get;
      set;
    }
  }
}
