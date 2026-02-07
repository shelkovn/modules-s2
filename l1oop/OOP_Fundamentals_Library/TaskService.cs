using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    public class TaskService
    {
        public void AssignTask(ITaskmanager assigner, Employee employee, string task)
        {
            assigner.AssignTaskToEmployee(employee, task);
        }
    }
}
