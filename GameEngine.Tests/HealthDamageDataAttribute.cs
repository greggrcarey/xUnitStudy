using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace GameEngine.Tests
{
    internal class HealthDamageDataAttribute : DataAttribute
    {
        //The data attribute pattern can also be used with external data
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100 };
            yield return new object[] { 1, 99 };
            yield return new object[] { 50, 50 };
            yield return new object[] { 75, 25 };
            yield return new object[] { 101, 1 };
        }
    }
}
