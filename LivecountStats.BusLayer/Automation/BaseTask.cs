using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.BusLayer.Automation
{
    public abstract class BaseTask
    {
        public abstract Task<int> Execute();
        public event EventHandler<string> Update;
        protected void OnUpdate(string param)
        {
            Update?.Invoke(this, param);
        }
    }
}
