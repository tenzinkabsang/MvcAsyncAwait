﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using WebApi.Models;
using WebApi.Utility;

namespace WebApi.Controllers
{
    public class GizmosController : ApiController
    {
        public async Task<IEnumerable<Gizmo>> GetAllGizmos(CancellationToken cancelToken)
        {
            // "Simulate" this operation took a long time, but was able to run without
            // blocking the calling thread (i.e., it's doing I/O operations which are async)
            // We use Task.Delay rather than Thread.Sleep, because Task.Delay returns
            // the thread immediately back to the thread-pool, whereas Thread.Sleep blocks it.
            // Task.Delay is essentially the asynchronous version of Thread.Sleep:

            await Task.Delay(Util.GetDelay(), cancelToken);

            return Gizmo.GetGizmos();
        } 
      
        //public IEnumerable<Gizmo> GetAllGizmos()
        //{
        //    Thread.Sleep(3000);
        //    return Gizmo.GetGizmos();
        //}
    }
}
