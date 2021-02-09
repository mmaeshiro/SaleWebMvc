﻿using System;

namespace SaleWebMvc.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}
