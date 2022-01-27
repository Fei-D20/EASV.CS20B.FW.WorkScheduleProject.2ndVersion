using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Domain.IRepository
{
    public interface IWorkRecordRepository
    {
        WorkRecord Create(WorkRecord workRecord);
        List<WorkRecord> ReadAll();
        WorkRecord ReadById(int id);    
        List<WorkRecord> ReadByUserId(int id);
        List<WorkRecord> ReadByDate(DateTime dateTime);
        List<WorkRecord> ReadByWeek(DayOfWeek dayOfWeek);
        List<WorkRecord> ReadByUserIdAndMonth(int id,DateTime dateTime);
    }
}