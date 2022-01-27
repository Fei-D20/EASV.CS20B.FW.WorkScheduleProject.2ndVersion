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
        List<Model.WorkSchedule> GetScheduleByUserId(int employeeId);
        List<Model.WorkSchedule> GetScheduleByDate(DateTime date);
        List<Model.WorkSchedule> GetScheduleByUserIdAndMonth(int id,DateTime dateTime);
        List<Model.WorkSchedule> GetScheduleById(int id);
        List<Model.WorkSchedule> GetScheduleByWeek(DayOfWeek dayOfWeek);
    }
}