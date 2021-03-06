﻿namespace Superscribe.Engine
{
    using System.Collections.Generic;

    public interface IRouteData
    {
        dynamic Parameters { get; set; }

        IDictionary<string, object> Environment { get; set; }
        
        object Response { get; set; }
        
        bool ExtraneousMatch { get; set; }

        bool FinalFunctionExecuted { get; set; }

        bool NoMatchingFinalFunction { get; set; }
    }
}
