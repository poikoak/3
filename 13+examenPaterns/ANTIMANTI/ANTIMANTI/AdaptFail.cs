using System;
using System.Collections.Generic;
using System.Text;

namespace ANTIMANTI
{

    public interface ITarget
    {
      
        string GetRequest();
    }

    class Adapter1 : ITarget
    {
        private readonly PDF _adaptee;

        public Adapter1(PDF adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Adapter2 : ITarget
    {
        private readonly DLL _adaptee;

        public Adapter2(DLL adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }

    class Adapter3 : ITarget
    {
        private readonly EXE _adaptee;

        public Adapter3(EXE adaptee)
        {
            this._adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
    class PDF
    {
        public string GetSpecificRequest()
        {
            return "converts PDF to one common file format which will then be disinfected";
        }
    }

    class DLL
    {
        public string GetSpecificRequest()
        {
            return "converts DLL to one common file format which will then be disinfected";
        }
    }

    class EXE
    {
        public string GetSpecificRequest()
        {
            return "converts EXE to one common file format which will then be disinfected";
        }
    }
}
