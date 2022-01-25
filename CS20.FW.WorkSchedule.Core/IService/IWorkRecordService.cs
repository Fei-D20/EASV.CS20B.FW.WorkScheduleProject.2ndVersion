using System;
using System.Collections.Generic;
using CS20.FW.WorkSchedule.Core.Model;

namespace CS20.FW.WorkSchedule.Core.IService
{
    public interface IWorkRecordService
    {
        WorkRecord CheckIn(WorkRecord workRecord);
        WorkRecord CheckOut(WorkRecord workRecord);
        WorkRecord Modify(WorkRecord workRecord);
        WorkRecord Delete(WorkRecord workRecord);
        List<WorkRecord> GetAll();
        WorkRecord GetById(WorkRecord workRecord);
        List<WorkRecord> GetByEmployeeId(int employeeId);
        List<WorkRecord> GetByDate(DateTime dateTime);
    }
}