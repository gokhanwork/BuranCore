﻿using Buran.Core.MvcLibrary.ModelBinders.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Buran.Core.MvcLibrary.ModelBinders.Providers
{
    public class DayMonthYearModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.UnderlyingOrModelType == typeof(DayMonthYear))
            {
                return new Decimal2ModelBinder();
            }
            return null;
        }
    }
}
