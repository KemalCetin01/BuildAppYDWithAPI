using BuildAppYD.Core.CrossCuttingConcerns.Logging;
using BuildAppYD.Core.CrossCuttingConcerns.Logging.Log4Net;
using BuildAppYD.Core.Utilities.Interceptors;
using BuildAppYD.Core.Utilities.Messages;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildAppYD.Core.Aspectts.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}
