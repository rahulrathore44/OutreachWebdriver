using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Helpers.BaseClasses
{
    [TestClass]
    [DeploymentItem("Resources")]
    public class DeployResources 
    {
        [TestMethod,Description("Empty method to deploy the resources")]
        public void ResourceDeploy() { }
    }
}
