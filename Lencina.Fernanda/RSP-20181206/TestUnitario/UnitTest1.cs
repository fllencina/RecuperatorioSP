using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Exceptions;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaErrorUsuario()
        {
            try
            {
                Usuario test = new Usuario("Fernanda", "12");
                Assert.Fail();
            }
            catch(Exception exc)
            {              
            }
            
            
            
        }
    }
}
