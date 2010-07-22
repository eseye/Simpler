﻿using Castle.DynamicProxy;
using System;
using Simpler.Construction.Interceptors;

namespace Simpler.Construction.Tasks
{
    public class CreateTask : Task
    {
        // Inputs
        public Type TaskType { get; set; }

        // Outputs
        public object TaskInstance { get; private set; }

        public override void Execute()
        {
            if (Attribute.IsDefined(TaskType, typeof(ExecutionCallbacksAttribute)))
            {
                TaskInstance = new ProxyGenerator().CreateClassProxy(TaskType, new TaskExecutionInterceptor());
            }
            else
            {
                TaskInstance = Activator.CreateInstance(TaskType);
            }
        }
    }
}