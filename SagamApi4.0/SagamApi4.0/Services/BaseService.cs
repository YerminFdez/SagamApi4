using Data;
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace SagamApi4.Services
{
    public class BaseService : Repository, IDisposable
    {
        public BaseService(DbContext context):base(context)
        {

        }
        public void Dispose()
        {
            Context.Dispose();
        }
        
    }
}