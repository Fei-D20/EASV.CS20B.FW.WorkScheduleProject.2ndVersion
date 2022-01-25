using System;
using System.Collections.Generic;

namespace CS20.FW.WorkSchedule.Core.IService
{
    public interface IWorkScheduleService
    {
        Model.WorkSchedule Create(Model.WorkSchedule workSchedule);
        Model.WorkSchedule Modify(Model.WorkSchedule workSchedule);
        Model.WorkSchedule Delete(Model.WorkSchedule workSchedule);
        List<Model.WorkSchedule> GetAll();
        List<Model.WorkSchedule> GetScheduleByEmployeeId(int employeeId);
        List<Model.WorkSchedule> GetScheduleByDate(DateTime date);
        List<Model.WorkSchedule> GetScheduleByMonth(DateTime months);
    }
}