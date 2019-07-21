﻿using Our.Umbraco.SuperValueConverters.Extensions;
using Umbraco.Core.Composing;
using Umbraco.Web.PropertyEditors.ValueConverters;

namespace Our.Umbraco.SuperValueConverters.Startup
{
    public class MediaPickerComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.DisableConverter<MediaPickerValueConverter>();
        }
    }
}